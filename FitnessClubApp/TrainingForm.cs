using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FitnessClubApp
{
    public partial class TrainingForm : Form
    {
        private bool isAdmin;

        public TrainingForm()
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
                    SqlCommand cmd = new SqlCommand("sp_FilterTrainings", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Добавляем параметры фильтрации
                    DateTime? trainingDate = null;
                    if (chkFilterByDate.Checked)
                    {
                        trainingDate = dtpFilterTrainingDate.Value.Date;
                    }
                    cmd.Parameters.AddWithValue("@TrainingDate", trainingDate.HasValue ? (object)trainingDate.Value : DBNull.Value);

                    int? trainerId = null;
                    if (chkFilterByTrainer.Checked && cbFilterTrainer.SelectedValue != null)
                    {
                        trainerId = Convert.ToInt32(cbFilterTrainer.SelectedValue);
                    }
                    cmd.Parameters.AddWithValue("@TrainerId", trainerId.HasValue ? (object)trainerId.Value : DBNull.Value);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No trainings found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                // Load customers
                string customerQuery = "SELECT Id_customer, C_fullname FROM CUSTOMER";
                DataTable customerDt = DataAccess.GetDataTable(customerQuery);
                cbCustomer.DataSource = customerDt;
                cbCustomer.DisplayMember = "C_fullname";
                cbCustomer.ValueMember = "Id_customer";

                // Load trainers
                string trainerQuery = "SELECT Id_trainer, T_fullname FROM TRAINER";
                DataTable trainerDt = DataAccess.GetDataTable(trainerQuery);
                cbTrainer.DataSource = trainerDt.Copy();
                cbTrainer.DisplayMember = "T_fullname";
                cbTrainer.ValueMember = "Id_trainer";

                // Load trainers for filter
                cbFilterTrainer.DataSource = trainerDt.Copy();
                cbFilterTrainer.DisplayMember = "T_fullname";
                cbFilterTrainer.ValueMember = "Id_trainer";
                cbFilterTrainer.SelectedIndex = -1;

                // Load training types
                string typeQuery = "SELECT Id_training_type, training_type_name FROM Training_type";
                DataTable typeDt = DataAccess.GetDataTable(typeQuery);
                cbTrainingType.DataSource = typeDt;
                cbTrainingType.DisplayMember = "training_type_name";
                cbTrainingType.ValueMember = "Id_training_type";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbCustomer.SelectedValue == null || cbTrainer.SelectedValue == null || cbTrainingType.SelectedValue == null)
            {
                MessageBox.Show("Please select all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int customerId = Convert.ToInt32(cbCustomer.SelectedValue);
            int trainerId = Convert.ToInt32(cbTrainer.SelectedValue);
            int typeId = Convert.ToInt32(cbTrainingType.SelectedValue);
            DateTime trainingDate = dtpTrainingDate.Value;

            try
            {
                string query = "INSERT INTO TRAINING (Id_customer, Id_trainer, Id_training_type, Training_date) " +
                               "VALUES (@CustomerId, @TrainerId, @TypeId, @TrainingDate)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@CustomerId", customerId),
                    new SqlParameter("@TrainerId", trainerId),
                    new SqlParameter("@TypeId", typeId),
                    new SqlParameter("@TrainingDate", trainingDate)
                };
                DataAccess.ExecuteNonQuery(query, parameters);
                LoadData();
                MessageBox.Show("Training added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a training to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbCustomer.SelectedValue == null || cbTrainer.SelectedValue == null || cbTrainingType.SelectedValue == null)
            {
                MessageBox.Show("Please select all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id_training"].Value);
            int customerId = Convert.ToInt32(cbCustomer.SelectedValue);
            int trainerId = Convert.ToInt32(cbTrainer.SelectedValue);
            int typeId = Convert.ToInt32(cbTrainingType.SelectedValue);
            DateTime trainingDate = dtpTrainingDate.Value;

            try
            {
                string query = "UPDATE TRAINING SET Id_customer = @CustomerId, Id_trainer = @TrainerId, " +
                               "Id_training_type = @TypeId, Training_date = @TrainingDate WHERE Id_training = @Id";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Id", id),
                    new SqlParameter("@CustomerId", customerId),
                    new SqlParameter("@TrainerId", trainerId),
                    new SqlParameter("@TypeId", typeId),
                    new SqlParameter("@TrainingDate", trainingDate)
                };
                DataAccess.ExecuteNonQuery(query, parameters);
                LoadData();
                MessageBox.Show("Training updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a training to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id_training"].Value);
            DialogResult result = MessageBox.Show("Are you sure you want to delete this training?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM TRAINING WHERE Id_training = @Id";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@Id", id)
                    };
                    DataAccess.ExecuteNonQuery(query, parameters);
                    LoadData();
                    MessageBox.Show("Training deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                cbCustomer.Text = dataGridView1.SelectedRows[0].Cells["C_fullname"].Value?.ToString() ?? "";
                cbTrainer.Text = dataGridView1.SelectedRows[0].Cells["T_fullname"].Value?.ToString() ?? "";
                cbTrainingType.Text = dataGridView1.SelectedRows[0].Cells["training_type_name"].Value?.ToString() ?? "";
                if (DateTime.TryParse(dataGridView1.SelectedRows[0].Cells["Training_date"].Value?.ToString(), out DateTime trainingDate))
                {
                    dtpTrainingDate.Value = trainingDate;
                }
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            chkFilterByDate.Checked = false;
            chkFilterByTrainer.Checked = false;
            cbFilterTrainer.SelectedIndex = -1;
            dtpFilterTrainingDate.Value = DateTime.Today;
            LoadData();
        }

        private void TrainingForm_Load(object sender, EventArgs e)
        {
        }
    }
}