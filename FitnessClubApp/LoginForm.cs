using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FitnessClubApp
{
    public partial class LoginForm : Form
    {
        public static string CurrentUserRole { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
        }



        private void btnLogin_Click(object sender, EventArgs e)
        {



            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string query = "SELECT Role FROM Users WHERE Username = @Username AND Password = @Password";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Username", username),
                    new SqlParameter("@Password", password)
                };

                DataTable dt = DataAccess.GetDataTable(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    CurrentUserRole = dt.Rows[0]["Role"].ToString();
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}