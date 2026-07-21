using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FitnessClubApp
{
    public partial class ChartForm : Form
    {
        private bool isAdmin;

        public ChartForm()
        {
            InitializeComponent();
            isAdmin = LoginForm.CurrentUserRole == "Admin";
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                string query = "SELECT TT.training_type_name, COUNT(T.Id_training) AS TrainingCount " +
                               "FROM TRAINING T " +
                               "JOIN Training_type TT ON T.Id_training_type = TT.Id_training_type " +
                               "GROUP BY TT.training_type_name";
                DataTable dt = DataAccess.GetDataTable(query);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerateChart_Click(object sender, EventArgs e)
        {
            // Simple chart generation logic
            chart1.Series["TrainingCount"].Points.Clear();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["training_type_name"].Value != null && row.Cells["TrainingCount"].Value != null)
                {
                    string typeName = row.Cells["training_type_name"].Value.ToString();
                    int count = Convert.ToInt32(row.Cells["TrainingCount"].Value);
                    chart1.Series["TrainingCount"].Points.AddXY(typeName, count);
                }
            }
        }

        private void ChartForm_Load(object sender, EventArgs e)
        {

        }
    }
}