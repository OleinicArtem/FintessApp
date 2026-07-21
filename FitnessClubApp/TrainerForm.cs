using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Linq;

namespace FitnessClubApp
{
    public partial class TrainerForm : Form
    {
        private bool isAdmin;

        public TrainerForm()
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
                string query = "SELECT T.Id_trainer, T.T_fullname, T.Trainer_telefon_number AS Phone, S.Specialozation_name " +
                               "FROM TRAINER T " +
                               "JOIN Specialization S ON T.id_specialization = S.Id_specialization";
                DataTable dt = DataAccess.GetDataTable(query);
                dataGridView1.DataSource = dt;
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
                string query = "SELECT Id_specialization, Specialozation_name FROM Specialization";
                DataTable dt = DataAccess.GetDataTable(query);
                cbSpecialization.DataSource = dt;
                cbSpecialization.DisplayMember = "Specialozation_name";
                cbSpecialization.ValueMember = "Id_specialization";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetNextTrainerId()
        {
            try
            {
                string query = "SELECT ISNULL(MAX(Id_trainer), 0) + 1 FROM TRAINER";
                DataTable dt = DataAccess.GetDataTable(query);
                return Convert.ToInt32(dt.Rows[0][0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting next Trainer ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1; // Возвращаем -1 в случае ошибки
            }
        }   

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            if (cbSpecialization.SelectedValue == null)
            {
                MessageBox.Show("Please select a specialization.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int specializationId = Convert.ToInt32(cbSpecialization.SelectedValue);

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Удаляем нечисловые символы из номера телефона
            phone = new string(phone.Where(char.IsDigit).ToArray());
            if (phone.Length != 9)
            {
                MessageBox.Show("Phone number must be exactly 9 digits.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int newTrainerId = GetNextTrainerId();
            if (newTrainerId == -1)
            {
                return; // Прерываем выполнение, если не удалось получить ID
            }

            try
            {
                string query = "INSERT INTO TRAINER (Id_trainer, T_fullname, Trainer_telefon_number, id_specialization) " +
                               "VALUES (@TrainerId, @FullName, @Phone, @SpecializationId)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TrainerId", newTrainerId),
                    new SqlParameter("@FullName", fullName),
                    new SqlParameter("@Phone", phone),
                    new SqlParameter("@SpecializationId", specializationId)
                };
                DataAccess.ExecuteNonQuery(query, parameters);
                LoadData();
                ClearFields();
                MessageBox.Show("Trainer added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding trainer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a trainer to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id_trainer"].Value);
            string fullName = txtFullName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            if (cbSpecialization.SelectedValue == null)
            {
                MessageBox.Show("Please select a specialization.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int specializationId = Convert.ToInt32(cbSpecialization.SelectedValue);

            phone = new string(phone.Where(char.IsDigit).ToArray());
            if (phone.Length != 9)
            {
                MessageBox.Show("Phone number must be exactly 9 digits.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string query = "UPDATE TRAINER SET T_fullname = @FullName, Trainer_telefon_number = @Phone, " +
                               "id_specialization = @SpecializationId WHERE Id_trainer = @Id";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Id", id),
                    new SqlParameter("@FullName", fullName),
                    new SqlParameter("@Phone", phone),
                    new SqlParameter("@SpecializationId", specializationId)
                };
                DataAccess.ExecuteNonQuery(query, parameters);
                LoadData();
                MessageBox.Show("Trainer updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating trainer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a trainer to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id_trainer"].Value);
            DialogResult result = MessageBox.Show("Are you sure you want to delete this trainer?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM TRAINER WHERE Id_trainer = @Id";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@Id", id)
                    };
                    DataAccess.ExecuteNonQuery(query, parameters);
                    LoadData();
                    ClearFields();
                    MessageBox.Show("Trainer deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting trainer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                txtFullName.Text = dataGridView1.SelectedRows[0].Cells["T_fullname"].Value.ToString();
                txtPhone.Text = dataGridView1.SelectedRows[0].Cells["Phone"].Value.ToString();
                cbSpecialization.Text = dataGridView1.SelectedRows[0].Cells["Specialozation_name"].Value.ToString();
            }
        }

        private void ClearFields()
        {
            txtFullName.Text = "";
            txtPhone.Text = "";
            cbSpecialization.SelectedIndex = -1;
        }

        private void TrainerForm_Load(object sender, EventArgs e)
        {

        }
    }
}