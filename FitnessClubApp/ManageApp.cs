using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace FitnessClubApp
{
    public partial class ManageApp : Form
    {
        private string connectionString = "Data Source=ARTEM;Initial Catalog=Training;Integrated Security=True"; // Замените на вашу строку подключения

        public ManageApp()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string checkTableQuery = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Users'";
                    using (SqlCommand cmd = new SqlCommand(checkTableQuery, conn))
                    {
                        int tableCount = (int)cmd.ExecuteScalar();
                        if (tableCount == 0)
                        {
                            MessageBox.Show("Table 'Users' does not exist. Please create it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                string query = "SELECT Id_user, Username,Role, IsAdmin FROM Users";
                DataTable dt = DataAccess.GetDataTable(query);
                dataGridViewUsers.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreateBackup_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Backup Files (*.bak)|*.bak",
                Title = "Save Backup File",
                FileName = $"Backup_{DateTime.Now:yyyyMMdd_HHmmss}.bak",
                InitialDirectory = @"C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\Backup" // Замените XX на версию SQL Server
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string backupPath = saveFileDialog.FileName;
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        if (!Directory.Exists(Path.GetDirectoryName(backupPath)))
                        {
                            Directory.CreateDirectory(Path.GetDirectoryName(backupPath));
                        }
                        string query = $"BACKUP DATABASE [Training] TO DISK = '{backupPath}' WITH FORMAT, MEDIANAME = 'Z_SQLServerBackups', NAME = 'Full Backup of Training';";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Backup created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("Access denied. Please run the application as Administrator or choose a different directory with write permissions.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creating backup: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRestoreBackup_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Backup Files (*.bak)|*.bak",
                Title = "Select Backup File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string backupPath = openFileDialog.FileName;
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = $"USE master; ALTER DATABASE [Training] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; " +
                                       $"RESTORE DATABASE [Training] FROM DISK = '{backupPath}' WITH REPLACE; " +
                                       "ALTER DATABASE [Training] SET MULTI_USER;";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Backup restored successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadUsers();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error restoring backup: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            bool isAdmin = chkIsAdmin.Checked;
            string role = isAdmin ? "Admin" : "User"; // Определяем роль пользователя

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string query = "INSERT INTO Users (Username, Password,Role, IsAdmin) VALUES (@Username, @Password, @Role, @IsAdmin)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Username", username),
                    new SqlParameter("@Password", password), // Рекомендуется хешировать пароль в реальном приложении
                    new SqlParameter("@Role", role), 
                    new SqlParameter("@IsAdmin", isAdmin)
                };
                DataAccess.ExecuteNonQuery(query, parameters);
                LoadUsers();
                ClearUserFields();
                MessageBox.Show("User added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearUserFields()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            chkIsAdmin.Checked = false;
        }
    }
}