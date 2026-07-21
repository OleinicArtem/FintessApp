using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FitnessClubApp
{
    public partial class AbonementForm : Form
    {
        private bool isAdmin;

        public AbonementForm()
        {
            InitializeComponent();
            isAdmin = LoginForm.CurrentUserRole == "Admin";
            ConfigureAccess();
            LoadData();
            LoadComboBoxes();
        }

        private void ConfigureAccess()
        {
            if (!isAdmin)
            {
                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                dataGridView1.ReadOnly = true;
                btnAdd.FillColor = System.Drawing.Color.Gray;
                btnEdit.FillColor = System.Drawing.Color.Gray;
                btnDelete.FillColor = System.Drawing.Color.Gray;
            }
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccess.ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_FilterAbonements", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Добавляем параметры фильтрации
                    int? abonementTypeId = null;
                    if (chkFilterByType.Checked && cbFilterAbonementType.SelectedValue != null)
                    {
                        abonementTypeId = Convert.ToInt32(cbFilterAbonementType.SelectedValue);
                    }
                    cmd.Parameters.AddWithValue("@AbonementTypeId", abonementTypeId.HasValue ? (object)abonementTypeId.Value : DBNull.Value);

                    int? validity = null;
                    if (chkFilterByValidity.Checked && int.TryParse(txtFilterValidity.Text.Trim(), out int validityValue))
                    {
                        validity = validityValue;
                    }
                    cmd.Parameters.AddWithValue("@Validity", validity.HasValue ? (object)validity.Value : DBNull.Value);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No abonements found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadComboBoxes()
        {
            try
            {
                string query = "SELECT Id_abonement_type, abonement_type_name FROM Abonement_type";
                DataTable dt = DataAccess.GetDataTable(query);
                cbAbonementType.DataSource = dt.Copy();
                cbAbonementType.DisplayMember = "abonement_type_name";
                cbAbonementType.ValueMember = "Id_abonement_type";

                // Заполняем фильтр по типу абонемента
                cbFilterAbonementType.DataSource = dt.Copy();
                cbFilterAbonementType.DisplayMember = "abonement_type_name";
                cbFilterAbonementType.ValueMember = "Id_abonement_type";
                cbFilterAbonementType.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetNextAbonementId()
        {
            try
            {
                string query = "SELECT ISNULL(MAX(Id_abonement), 0) + 1 FROM ABONEMENT";
                DataTable dt = DataAccess.GetDataTable(query);
                return Convert.ToInt32(dt.Rows[0][0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting next Abonement ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string validityText = txtValidity.Text.Trim();
            if (cbAbonementType.SelectedValue == null)
            {
                MessageBox.Show("Please select an abonement type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int abonementTypeId = Convert.ToInt32(cbAbonementType.SelectedValue);

            if (string.IsNullOrEmpty(validityText))
            {
                MessageBox.Show("Please fill in the validity field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(validityText, out int validity))
            {
                MessageBox.Show("Validity must be a number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int newAbonementId = GetNextAbonementId();
            if (newAbonementId == -1)
            {
                return;
            }

            try
            {
                string query = "INSERT INTO ABONEMENT (Id_abonement, VALIDITY, Id_abonement_type) VALUES (@AbonementId, @Validity, @AbonementTypeId)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@AbonementId", newAbonementId),
                    new SqlParameter("@Validity", validity),
                    new SqlParameter("@AbonementTypeId", abonementTypeId)
                };
                DataAccess.ExecuteNonQuery(query, parameters);
                LoadData();
                ClearFields();
                MessageBox.Show("Abonement added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding abonement: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an abonement to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id_abonement"].Value);
            string validityText = txtValidity.Text.Trim();
            if (cbAbonementType.SelectedValue == null)
            {
                MessageBox.Show("Please select an abonement type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int abonementTypeId = Convert.ToInt32(cbAbonementType.SelectedValue);

            if (!int.TryParse(validityText, out int validity))
            {
                MessageBox.Show("Validity must be a number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string query = "UPDATE ABONEMENT SET VALIDITY = @Validity, Id_abonement_type = @AbonementTypeId WHERE Id_abonement = @Id";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Id", id),
                    new SqlParameter("@Validity", validity),
                    new SqlParameter("@AbonementTypeId", abonementTypeId)
                };
                DataAccess.ExecuteNonQuery(query, parameters);
                LoadData();
                MessageBox.Show("Abonement updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating abonement: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an abonement to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id_abonement"].Value);
            DialogResult result = MessageBox.Show("Are you sure you want to delete this abonement?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM ABONEMENT WHERE Id_abonement = @Id";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@Id", id)
                    };
                    DataAccess.ExecuteNonQuery(query, parameters);
                    LoadData();
                    ClearFields();
                    MessageBox.Show("Abonement deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting abonement: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                txtValidity.Text = dataGridView1.SelectedRows[0].Cells["VALIDITY"].Value.ToString();
                cbAbonementType.Text = dataGridView1.SelectedRows[0].Cells["abonement_type_name"].Value.ToString();
            }
        }

        private void ClearFields()
        {
            txtValidity.Text = "";
            cbAbonementType.SelectedIndex = -1;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            chkFilterByType.Checked = false;
            chkFilterByValidity.Checked = false;
            cbFilterAbonementType.SelectedIndex = -1;
            txtFilterValidity.Text = "";
            LoadData();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}