
using GYMDatabaseProject.DataAccess;
using GYMDatabaseProject.Models;
using GymProjectUI.Validation;
using GYMProjectUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        List<Users> users = new List<Users>();
        public bool EmailMatchValidationProp { get; set; }
        public bool EmailSyntaxValidationProp { get; set; }
        public bool EmailExistsValidationProp { get; set; }
        public bool PasswordsMatchValidationProp { get; set; }

        public Register()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var textbox in registerGrid.Children.OfType<TextBox>())
            {
                if (textbox.Text == "")
                {
                    textbox.BorderBrush = Brushes.Red;
                    textbox.Text = "Please fill this field!";
                }
            }

            bool emailMatchValid = EmailMatchValidation(email.Text, confirmEmail.Text);
            bool emailSyntaxCheck = EmailSyntaxCheck(email.Text);
            bool emailExists = EmailExists(confirmEmail.Text);
            bool passwordMatchValid = PasswordMatchValidation(password.Password, confirmPassword.Password);
            bool passwordValidation = await Password_Control.Validate_Password_RegisterAsync(confirmPassword.Password);

            dateOfBirth.SelectedDate = dateOfBirth.SelectedDate.GetValueOrDefault(DateTime.Now.Date);

            if (DateTime.Now.Year - dateOfBirth.SelectedDate.Value.Year < 13 || DateTime.Now.Year - dateOfBirth.SelectedDate.Value.Year > 80)
                MessageBox.Show("Age must be above 13\nOr under 80!");
            else if (city.SelectedIndex == 0) MessageBox.Show("Please enter your city!");
            else if (gender.SelectedIndex == 0) MessageBox.Show("Please enter your Gender!");
            else if (emailMatchValid && emailSyntaxCheck && !emailExists && passwordMatchValid && passwordValidation)
            {
                await InsertUserAsync();
                OpenMainWindow();
            }
        }

        // Other Register window events //////////////////////////////////////

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void firstName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = int.TryParse(e.Text, out int result);
        }

        private void lastName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = int.TryParse(e.Text, out int result);
        }

        private void id_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out int result);
        }

        private void phoneNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out int result);
        }

        private void dateOfBirth_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out int result);
        }

        //////////////////////////////////////////////////////////////


        // Async navigation methods //////////////////////////////////

        private async Task InsertUserAsync()
        {
            using (var dbContext = new DatabaseGYM())
            {
                var user = new Users
                {
                    User_ID = int.Parse(id.Text),
                    FirstName = firstName.Text.ToUpper(),
                    LastName = lastName.Text.ToUpper(),
                    Email = email.Text.ToUpper(),
                    _Password = password.Password,
                    DOB = (DateTime)dateOfBirth.SelectedDate.Value.Date,
                    PhoneNumber = int.Parse(phoneNumber.Text),
                    _Address = address.Text.ToUpper(),
                    City = city.Text.ToUpper(),
                    Age = DateTime.Now.Year - dateOfBirth.SelectedDate.Value.Year,
                    Gender = gender.Text.ToUpper(),
                    Admin = new Admins()
                    {
                        FullName = firstName.Text.ToUpper() + " " + lastName.Text.ToUpper(),
                        User_ID = int.Parse(id.Text),
                        Email = email.Text.ToUpper(),
                        AdminMessages = new List<Messages>
                        {
                            new Messages()
                            {
                                _From_ID = 332557653,
                                _To_ID = int.Parse(id.Text),
                                Title = "Welcome",
                                Body = "I'm very glad to see a new admin here!, last one was lame..."
                            },

                            new Messages()
                            {
                                _From_ID = 549762433,
                                _To_ID = int.Parse(id.Text),
                                Title = "Program",
                                Body = "Hope you like this program! its very creative!"
                            },

                            new Messages()
                            {
                                _From_ID = 559224309,
                                _To_ID = int.Parse(id.Text),
                                Title = "Plan discount",
                                Body = "Can i have free 1 year discount? :)"
                            }
                        }
                    },
                    JoinedDate = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                };

                users.Add(user);
                await dbContext.AddRangeAsync(users.ToArray());
                await dbContext.SaveChangesAsync();
            }
        }

        private void OpenMainWindow()
        {

            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        //////////////////////////////////////////////////////////////

        // Validation failed results methids /////////////////////////

        public bool EmailMatchValidation(string email, string confirmedEmail)
        {
            if (email == confirmedEmail) return true;
            else
            {
                this.email.Text = "";
                confirmEmail.Text = "";
                emailNotMatch.Visibility = Visibility.Visible;
                this.email.BorderBrush = Brushes.Red;
                confirmEmail.BorderBrush = Brushes.Red;
                return false;
            }
            
        }

        public bool EmailSyntaxCheck(string email)
        {
            if (!email.Contains('@') && !email.Contains('.') || email == null)
            {
                emailNotMatch.Content = "Email syntax is invalid! Please use '@' or '.'";
                emailNotMatch.Visibility = Visibility.Visible;
                this.email.BorderBrush = Brushes.Red;
                this.confirmEmail.BorderBrush = Brushes.Red;
                return false;
            }
            return true;
        }

        public bool EmailExists(string email)
        {
            using (var dbContext = new DatabaseGYM())
            {
                dbContext.Database.EnsureDeleted();
                dbContext.Database.EnsureCreated();

                if (dbContext.Users.Where(user => user.Email == email).Any())
                {
                    this.email.Text = "";
                    confirmEmail.Text = "";
                    emailNotMatch.Content = "Email already exists!";
                    emailNotMatch.Visibility = Visibility.Visible;
                    this.email.BorderBrush = Brushes.Red;
                    confirmEmail.BorderBrush = Brushes.Red;
                    return true;
                }
                else return false;
            }
        }

        public bool PasswordMatchValidation(string password, string confirmPassword)
        {
            if (password != confirmPassword)
            {
                passwordNotMatch.Visibility = Visibility.Visible;
                this.password.Password = "";
                this.confirmPassword.Password = "";
                this.password.BorderBrush = Brushes.Red;
                this.confirmPassword.BorderBrush = Brushes.Red;
                return false;
            }
            else return true;
        }
        //////////////////////////////////////////////////////////////

    }
}
