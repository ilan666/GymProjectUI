using GymProjectUI.WPF_APPS;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using GymProjectUI.Utilities;
using GYMDatabaseProject.DataAccess;
using GYMDatabaseProject.Models;

namespace GYMProjectUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(idText.Text, out int id))
            {
                if (Password_Control.Validate_Password_On_DB(id, passwordText.Password.ToString()))
                {
                    SetUp();
                    MainUI mainUI = new MainUI();
                    mainUI.Show();
                    using (var dbContext = new DatabaseGYM())
                    {
                        var user = dbContext.Users.FirstOrDefault(u => u.User_ID == id);
                        Utilities.User = user;
                    }
                    mainUI.ShowDisplay();
                    this.Close();
                }
                else
                {
                    incorrectDataLabel.Content = "ID or Password doesn't exists";
                    incorrectDataLabel.Visibility = Visibility.Visible;
                    idText.Text = "";
                    passwordText.Password = "";
                }
            }
        }

        private void btnForgotPassword_Click(object sender, RoutedEventArgs e)
        {
            ForgotPasswordEmail forgotPasswordWindow = new ForgotPasswordEmail();
            forgotPasswordWindow.Show();
            this.Close();
        }

        private void btnCreateNewAccount_Click(object sender, RoutedEventArgs e)
        {
            Register registerWindow = new Register();
            registerWindow.Show();
            this.Close();
        }

        private void idText_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out int result);
        }

        public void SetUp()
        {
            List<Users> users = new List<Users>();
            List<Plans> plans = new List<Plans>();

            using(var dbContext = new DatabaseGYM())
            {
                var user1 = new Users()
                {
                    User_ID = 332557653,
                    FirstName = "JACK",
                    LastName = "BECKERS",
                    Email = "JBECK@GMAIL.COM",
                    _Password = "Jack123",
                    DOB = new DateTime(2001, 8, 13),
                    PhoneNumber = 0538998721,
                    _Address = "YONATAN NETANYAHU 3",
                    City = "ASHKELON",
                    Age = DateTime.Now.Year - 2001,
                    Gender = "MALE",
                    JoinedDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                    Plan_ID = 3
                };

                var user2 = new Users()
                {
                    User_ID = 549762433,
                    FirstName = "EMILY",
                    LastName = "STARR",
                    Email = "ESTR@GMAIL.COM",
                    _Password = "Emily123",
                    DOB = new DateTime(1997, 2, 17),
                    PhoneNumber = 0542238829,
                    _Address = "HAGALIM 1",
                    City = "ASHDOD",
                    Age = DateTime.Now.Year - 1997,
                    Gender = "FEMALE",
                    JoinedDate = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                };

                var user3 = new Users()
                {
                    User_ID = 559224309,
                    FirstName = "DENIS",
                    LastName = "URKUTZ",
                    Email = "DU@GMAIL.COM",
                    _Password = "Denis123",
                    DOB = new DateTime(2002, 2, 17),
                    PhoneNumber = 0507708093,
                    _Address = "KOHAVIM 3",
                    City = "BAT-YAM",
                    Age = DateTime.Now.Year - 2002,
                    Gender = "MALE",
                    JoinedDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                    Plan_ID = 1
                };

                var plan1 = new Plans()
                {
                    _Plan = "12 Months plan",
                    Cost = 30
                };

                var plan2 = new Plans()
                {
                    _Plan = "6 Months plan",
                    Cost = 40
                };

                var plan3 = new Plans()
                {
                    _Plan = "3 Months plan",
                    Cost = 50
                };


                users.Add(user1);
                users.Add(user2);
                users.Add(user3);

                plans.Add(plan1);
                plans.Add(plan2);
                plans.Add(plan3);

                dbContext.AddRange(users.ToArray());
                dbContext.SaveChanges();
                dbContext.AddRange(plans.ToArray());
                dbContext.SaveChanges();
            }
        }
    }
}
