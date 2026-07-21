using System;
using System.Windows.Forms;

namespace FitnessClubApp
{
    public partial class MainForm : Form
    {
        private bool isAdmin;

        public MainForm()
        {
            InitializeComponent();
            isAdmin = LoginForm.CurrentUserRole == "Admin";
            ConfigureAccess();
        }

        private void ConfigureAccess()
        {
            btnManageApp.Visible = isAdmin; // Показываем кнопку только для админа
        }

        private void btnManageApp_Click(object sender, EventArgs e)
        {
            ManageApp manageApp = new ManageApp();
            manageApp.ShowDialog();
        }

        // Другие существующие методы (CustomerForm, TrainerForm и т.д.) остаются без изменений
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            CustomerForm customerForm = new CustomerForm();
            customerForm.ShowDialog();
        }

        private void btnTrainer_Click(object sender, EventArgs e)
        {
            TrainerForm trainerForm = new TrainerForm();
            trainerForm.ShowDialog();
        }

        private void btnAbonement_Click(object sender, EventArgs e)
        {
            AbonementForm abonementForm = new AbonementForm();
            abonementForm.ShowDialog();
        }

        private void btnTraining_Click(object sender, EventArgs e)
        {
            TrainingForm trainingForm = new TrainingForm();
            trainingForm.ShowDialog();
        }

        private void btnChart_Click(object sender, EventArgs e)
        {
            ChartForm chartForm = new ChartForm();
            chartForm.ShowDialog();
        }

        private void btHelp_Click(object sender, EventArgs e)
        {
            string helpMessage =
                "Fitness Club App\n\n" +
                "Version: 1.0\n" +
                "Developed by: Oleinic Artiom\n" +
                "Date: June 04, 2025\n" +
                "Description: This application is designed to manage a fitness club. " +
                "Users can view customer, trainer, abonement, training, and chart data, " +
                "while administrators have full access to add, edit, and delete records.\n\n" +
                "Features:\n" +
                "- User and Admin login system\n" +
                "- View and manage customer, trainer, abonement, and training data\n" +
                "- Chart visualization\n" +
                "- Secure registration with transactions\n" +
                "- Role-based access control\n\n" +
                "Contact: support@fitnessclubapp.com";

            MessageBox.Show(helpMessage, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}