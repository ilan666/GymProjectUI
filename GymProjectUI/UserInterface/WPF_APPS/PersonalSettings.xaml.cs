using GYMDatabaseProject.DataAccess;
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

namespace GymProjectUI.UserInterface.WPF_APPS
{
    /// <summary>
    /// Interaction logic for PersonalSettings.xaml
    /// </summary>
    public partial class PersonalSettings : Window
    {
        public PersonalSettings()
        {
            InitializeComponent();

            using (var dbContext = new DatabaseGYM())
            {
                var user = dbContext.Users.FirstOrDefault(u => u.User_ID == Utilities.Utilities.User.User_ID);

                firstName.Text = user.FirstName;
                lastName.Text = user.LastName;
                email.Text = user.Email;
                id.Text = user.User_ID.ToString();
                password.Text = user._Password.ToString();
                gender.Text = user.Gender.ToString();
                phoneNumber.Text = user.PhoneNumber.ToString();
                address.Text = user._Address;
                city.Text = user.City.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (TextBox textbox in grid.Children.OfType<TextBox>())
            {
                textbox.Visibility = Visibility.Visible;
            }

            using (var dbContext = new DatabaseGYM())
            {
                var user = dbContext.Users.FirstOrDefault(u => u.User_ID == Utilities.Utilities.User.User_ID);

                firstNameText.Text = user.FirstName;
                lastNameText.Text = user.LastName;
                emailText.Text = user.Email;
                idText.Text = user.User_ID.ToString();
                passwordText.Text = user._Password.ToString();
                genderText.Text = user.Gender.ToString();
                phoneText.Text = user.PhoneNumber.ToString();
                addressText.Text = user._Address;
                cityText.Text = user.City.ToString();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (var dbContext = new DatabaseGYM())
            {
                var user = dbContext.Users.FirstOrDefault(u => u.User_ID == Utilities.Utilities.User.User_ID);

                user.FirstName = firstNameText.Text;
                user.LastName = lastName.Text;
                user.Email = emailText.Text;
                user.User_ID = int.Parse(idText.Text);
                user._Password = passwordText.Text;
                user.Gender = genderText.Text;
                user.PhoneNumber = int.Parse(phoneText.Text);
                user._Address = addressText.Text;
                user.City = cityText.Text;

                Utilities.Utilities.User.FirstName = firstNameText.Text;
                Utilities.Utilities.User.LastName = lastName.Text;
                Utilities.Utilities.User.Email = emailText.Text;
                Utilities.Utilities.User.User_ID = int.Parse(idText.Text);
                Utilities.Utilities.User._Password = passwordText.Text;
                Utilities.Utilities.User.Gender = genderText.Text;
                Utilities.Utilities.User.PhoneNumber = int.Parse(phoneText.Text);
                Utilities.Utilities.User._Address = addressText.Text;
                Utilities.Utilities.User.City = cityText.Text;

                foreach (TextBox textbox in grid.Children.OfType<TextBox>())
                {
                    textbox.Visibility = Visibility.Hidden;
                }

                firstName.Text = user.FirstName;
                lastName.Text = user.LastName;
                email.Text = user.Email;
                id.Text = user.User_ID.ToString();
                password.Text = user._Password.ToString();
                gender.Text = user.Gender.ToString();
                phoneNumber.Text = user.PhoneNumber.ToString();
                address.Text = user._Address;
                city.Text = user.City.ToString();

                dbContext.Update(user);
                dbContext.SaveChanges();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainUI main = new MainUI();
            main.Show();
            main.ShowDisplay();
            this.Close();
        }
    }
}
