using GYMDatabaseProject.DataAccess;
using GYMDatabaseProject.Models;
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
    /// Interaction logic for Plans.xaml
    /// </summary>
    public partial class PlansUI : Window
    {
        //public int User_ID { get; set; }

        public PlansUI()
        {
            InitializeComponent();
        }

        //public void PassIDDataFromMain(int id)
        //{
        //    User_ID = id;
        //}

        private void btn3Months_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainUI mainUI = new MainUI();
                using (var dbContext = new DatabaseGYM())
                {
                    var user = dbContext.Users.FirstOrDefault(u => u.User_ID == Utilities.Utilities.User.User_ID);
                    var plan = dbContext.Plans.FirstOrDefault(p => p.Plan_ID == 1);

                    user.Plan_ID = plan.Plan_ID;
                    mainUI.subscription.Text = plan._Plan.ToString();

                    user.PlanExpiration = DateTime.Now.Date.AddMonths(3);
                    mainUI.expireDatePlan.Text = user.PlanExpiration.ToShortDateString();

                    dbContext.Update(user);
                    dbContext.SaveChanges();

                    Utilities.Utilities.User.Plan_ID = plan.Plan_ID;
                }

                MessageBox.Show("Successfully purchased package!\n\n" +
                    "For the project tester.\n" +
                    "The purchase action had to be included\n" +
                    "With paypal connection and navigation.\n" +
                    "Since this is a prototype test project\n" +
                    "I have skipped this actions.\n" +
                    "Due that, You can instantly change/Update your\n" +
                    "Plan any time.");
                mainUI.Show();
                //mainUI.PassIDData(User_ID);
                mainUI.ShowDisplay();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Some Error occured");
            }
        }

        private void btn6Months_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainUI mainUI = new MainUI();
                using (var dbContext = new DatabaseGYM())
                {
                    var user = dbContext.Users.FirstOrDefault(u => u.User_ID == Utilities.Utilities.User.User_ID);
                    var plan = dbContext.Plans.FirstOrDefault(p => p.Plan_ID == 2);

                    user.Plan_ID = plan.Plan_ID;
                    mainUI.subscription.Text = plan._Plan.ToString();

                    user.PlanExpiration = DateTime.Now.Date.AddMonths(6);
                    mainUI.expireDatePlan.Text = user.PlanExpiration.ToShortDateString();

                    dbContext.Update(user);
                    dbContext.SaveChanges();

                    Utilities.Utilities.User.Plan_ID = plan.Plan_ID;
                }

                MessageBox.Show("Successfully purchased package!\n\n" +
                    "For the project tester.\n" +
                    "The purchase action had to be included\n" +
                    "With paypal connection and navigation.\n" +
                    "Since this is a prototype test project\n" +
                    "I have skipped this actions.\n" +
                    "Due that, You can instantly change/Update your\n" +
                    "Plan any time.");
                mainUI.Show();
                //mainUI.PassIDData(User_ID);
                mainUI.ShowDisplay();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Some Error occured");
            }
        }

        private void btn12Months_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainUI mainUI = new MainUI();
                using (var dbContext = new DatabaseGYM())
                {
                    var user = dbContext.Users.FirstOrDefault(u => u.User_ID == Utilities.Utilities.User.User_ID);
                    var plan = dbContext.Plans.FirstOrDefault(p => p.Plan_ID == 3);

                    user.Plan_ID = plan.Plan_ID;
                    mainUI.subscription.Text = plan._Plan.ToString();

                    user.PlanExpiration = DateTime.Now.Date.AddMonths(12);
                    mainUI.expireDatePlan.Text = user.PlanExpiration.ToShortDateString();

                    dbContext.Update(user);
                    dbContext.SaveChanges();

                    Utilities.Utilities.User.Plan_ID = plan.Plan_ID;
                }

                MessageBox.Show("Successfully purchased package!\n\n" +
                    "For the project tester.\n" +
                    "The purchase action had to be included\n" +
                    "With paypal connection and navigation.\n" +
                    "Since this is a prototype test project\n" +
                    "I have skipped this actions.\n" +
                    "Due that, You can instantly change/Update your\n" +
                    "Plan any time.");
                mainUI.Show();
                //mainUI.PassIDData(User_ID);
                mainUI.ShowDisplay();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Some Error occured");
            }
        }
    }
}
