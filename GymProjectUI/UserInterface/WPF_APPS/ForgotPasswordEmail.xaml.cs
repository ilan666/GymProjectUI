using GYMDatabaseProject.Models;
using GymProjectUI.Validation;
using GymProjectUI.WPF_APPS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GYMProjectUI
{
    /// <summary>
    /// Interaction logic for ForgotPasswordEmail.xaml
    /// </summary>
    public partial class ForgotPasswordEmail : Window
    {

        public ForgotPasswordEmail()
        {
            InitializeComponent();
        }

        private async void BtnrecoverPasswordEmail_Click(object sender, RoutedEventArgs e)
        {
            var result = await EmailControl.EmailExists(recoverEmail.Text.ToUpper());
            if (result)
            {
                ForgotPasswordRecovery nextStep = new ForgotPasswordRecovery();
                nextStep.Show();
                nextStep.PassEmailData(recoverEmail.Text);
                this.Close();
            }
            else
            {
                emailNotExists.Visibility = Visibility.Visible;
            }
        }

        private void BtnbackToSignIn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
