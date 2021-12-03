using GYMDatabaseProject.DataAccess;
using GYMDatabaseProject.Models;
using GYMProjectUI;
using GymProjectUI.Validation;
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

namespace GymProjectUI.WPF_APPS
{
    /// <summary>
    /// Interaction logic for ForgotPasswordRecovery.xaml
    /// </summary>
    public partial class ForgotPasswordRecovery : Window
    {
        public string Email { get; set; }
        public ForgotPasswordRecovery()
        {
            InitializeComponent();
        }

        private void btnBackToSignIn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private async void btnSubmitChanges_Click(object sender, RoutedEventArgs e)
        {
            bool validatePassword = await Password_Control.Validate_Password_RegisterAsync(confirmPassBox.Password);
            if (newPassBox.Password != confirmPassBox.Password)
            {
                passwordsNotMatch.Visibility = Visibility.Visible;
                newPassBox.Password = "";
                confirmPassBox.Password = "";
                newPassBox.BorderBrush = Brushes.Red;
                confirmPassBox.BorderBrush = Brushes.Red;
            }
            else if (validatePassword)
            {
                try
                {
                    using (var dbContext = new DatabaseGYM())
                    {
                        var user = dbContext.Users.FirstOrDefault(u => u.Email == Email);

                        user._Password = confirmPassBox.Password;

                        dbContext.Update(user);
                        await dbContext.SaveChangesAsync();
                    }

                    MessageBox.Show("Password changed successfully");
                    MainWindow main = new MainWindow();
                    main.Show();
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Some error occured");
                }
            }
        }

        public void PassEmailData(string email)
        {
            Email = email;
        }
    }
}
