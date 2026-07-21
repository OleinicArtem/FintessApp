using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Linq;

namespace FitnessClubApp
{
    public partial class CustomerForm : Form
    {
        private bool isAdmin;

        public CustomerForm()
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
                    SqlCommand cmd = new SqlCommand("sp_SearchCustomersByName", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Добавляем параметр поиска
                    string customerName = txtSearchName.Text.Trim();
                    cmd.Parameters.AddWithValue("@CustomerName", string.IsNullOrEmpty(customerName) ? (object)DBNull.Value : customerName);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No customers found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                string query = "SELECT A.Id_abonement, AT.abonement_type_name " +
                               "FROM ABONEMENT A " +
                               "JOIN Abonement_type AT ON A.Id_abonement_type = AT.Id_abonement_type";
                DataTable dt = DataAccess.GetDataTable(query);
                cbAbonement.DataSource = dt;
                cbAbonement.DisplayMember = "abonement_type_name";
                cbAbonement.ValueMember = "Id_abonement";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetNextCustomerId()
        {
            try
            {
                string query = "SELECT ISNULL(MAX(Id_customer), 0) + 1 FROM CUSTOMER";
                DataTable dt = DataAccess.GetDataTable(query);
                return Convert.ToInt32(dt.Rows[0][0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting next Customer ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string idnp = txtIDNP.Text.Trim();
            string adress = txtAdress.Text.Trim();

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(idnp) || string.IsNullOrEmpty(adress))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbAbonement.SelectedValue == null)
            {
                MessageBox.Show("Please select an abonement.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int idAbonement = Convert.ToInt32(cbAbonement.SelectedValue);

            phone = new string(phone.Where(char.IsDigit).ToArray());
            if (phone.Length != 9)
            {
                MessageBox.Show("Phone number must be 9 digits.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!long.TryParse(idnp, out long idnpValue) || idnp.Length != 13)
            {
                MessageBox.Show("IDNP must be a 13-digit number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int newCustomerId = GetNextCustomerId();
            if (newCustomerId == -1)
            {
                return;
            }

            try
            {
                string query = "INSERT INTO CUSTOMER (Id_customer, C_fullname, Customer_telefon_number, IDNP, Adress, Id_abonement) " +
                               "VALUES (@CustomerId, @FullName, @Phone, @IDNP, @Adress, @Id_abonement)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@CustomerId", newCustomerId),
                    new SqlParameter("@FullName", fullName),
                    new SqlParameter("@Phone", phone),
                    new SqlParameter("@IDNP", idnpValue),
                    new SqlParameter("@Adress", adress),
                    new SqlParameter("@Id_abonement", idAbonement)
                };
                DataAccess.ExecuteNonQuery(query, parameters);
                LoadData();
                ClearFields();
                MessageBox.Show("Customer added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id_customer"].Value);
            string fullName = txtFullName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string idnp = txtIDNP.Text.Trim();
            string adress = txtAdress.Text.Trim();

            if (cbAbonement.SelectedValue == null)
            {
                MessageBox.Show("Please select an abonement.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int idAbonement = Convert.ToInt32(cbAbonement.SelectedValue);

            phone = new string(phone.Where(char.IsDigit).ToArray());
            if (phone.Length != 9)
            {
                MessageBox.Show("Phone number must be 9 digits.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!long.TryParse(idnp, out long idnpValue) || idnp.Length != 13)
            {
                MessageBox.Show("IDNP must be a 13-digit number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string query = "UPDATE CUSTOMER SET C_fullname = @FullName, Customer_telefon_number = @Phone, " +
                               "IDNP = @IDNP, Adress = @Adress, Id_abonement = @Id_abonement WHERE Id_customer = @Id";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Id", id),
                    new SqlParameter("@FullName", fullName),
                    new SqlParameter("@Phone", phone),
                    new SqlParameter("@IDNP", idnpValue),
                    new SqlParameter("@Adress", adress),
                    new SqlParameter("@Id_abonement", idAbonement)
                };
                DataAccess.ExecuteNonQuery(query, parameters);
                LoadData();
                MessageBox.Show("Customer updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id_customer"].Value);
            DialogResult result = MessageBox.Show("Are you sure you want to delete this customer?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM CUSTOMER WHERE Id_customer = @Id";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@Id", id)
                    };
                    DataAccess.ExecuteNonQuery(query, parameters);
                    LoadData();
                    ClearFields();
                    MessageBox.Show("Customer deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                txtFullName.Text = dataGridView1.SelectedRows[0].Cells["C_fullname"].Value?.ToString() ?? "";
                txtPhone.Text = dataGridView1.SelectedRows[0].Cells["Phone"].Value?.ToString() ?? "";
                txtIDNP.Text = dataGridView1.SelectedRows[0].Cells["IDNP"].Value?.ToString() ?? "";
                txtAdress.Text = dataGridView1.SelectedRows[0].Cells["Adress"].Value?.ToString() ?? "";
                cbAbonement.Text = dataGridView1.SelectedRows[0].Cells["abonement_type_name"].Value?.ToString() ?? "";
            }
        }

        private void ClearFields()
        {
            txtFullName.Text = "";
            txtPhone.Text = "";
            txtIDNP.Text = "";
            txtAdress.Text = "";
            cbAbonement.SelectedIndex = -1;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearchName.Text = "";
            LoadData();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}