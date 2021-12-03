using GYMDatabaseProject.DataAccess;
using GYMDatabaseProject.Models;
using GymProjectUI.Database.Models;
using GymProjectUI.WPF_APPS;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for AdminControl.xaml
    /// </summary>
    public partial class AdminControl : Window
    {
        public int index { get; set; }

        public AdminControl()
        {
            InitializeComponent();
        }

        private void btnDisplayAllUsersData_Click(object sender, RoutedEventArgs e)
        {
            usersDataGrid.Visibility = Visibility.Visible;
            addPlanView.Visibility = Visibility.Hidden;
            planViewBorder.Visibility = Visibility.Hidden;
            notificationView.Visibility = Visibility.Hidden;
            notifyViewBorder.Visibility = Visibility.Hidden;
            messagesView.Visibility = Visibility.Hidden;
            messagesViewBorder.Visibility = Visibility.Hidden;

            using (var dbContext = new DatabaseGYM())
            {
                var users = from User in dbContext.Users
                            select User;

                usersDataGrid.ItemsSource = users.ToList();
            }
        }

        private void btnDisplayUserData_Click(object sender, RoutedEventArgs e)
        {
            usersDataGrid.Visibility = Visibility.Visible;
            addPlanView.Visibility = Visibility.Hidden;
            planViewBorder.Visibility = Visibility.Hidden;
            notificationView.Visibility = Visibility.Hidden;
            notifyViewBorder.Visibility = Visibility.Hidden;
            messagesView.Visibility = Visibility.Hidden;
            messagesViewBorder.Visibility = Visibility.Hidden;

            using (var dbContext = new DatabaseGYM())
            {
                var users = from User in dbContext.Users
                            where User.User_ID == int.Parse(idText.Text)
                            select User;

                usersDataGrid.ItemsSource = users.ToList();
            }
        }

        private void btnAddUserNotify_Click(object sender, RoutedEventArgs e)
        {
            using(var dbContext = new DatabaseGYM())
            {
                if (idTextModify.Text == "")
                {
                    MessageBox.Show("Please fill the id TextBox!");
                }
                else if (!dbContext.Users.Where(p => p.User_ID == int.Parse(idTextModify.Text)).Any())
                {
                    MessageBox.Show("No such user...");
                }
                else
                {
                    usersDataGrid.Visibility = Visibility.Hidden;
                    notificationView.Visibility = Visibility.Visible;
                    notifyViewBorder.Visibility = Visibility.Visible;
                    addPlanView.Visibility = Visibility.Hidden;
                    planViewBorder.Visibility = Visibility.Hidden;
                    messagesView.Visibility = Visibility.Hidden;
                    messagesViewBorder.Visibility = Visibility.Hidden;
                }
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var dbContext = new DatabaseGYM())
            {
                if(dbContext.UserNotifications.Where(p => p.User_ID == int.Parse(idTextModify.Text)).Any())
                {
                    var notification = dbContext.UserNotifications.FirstOrDefault(p => p.User_ID == int.Parse(idTextModify.Text));

                    dbContext.Remove(notification);
                    dbContext.SaveChanges();
                }

                TextRange text = new TextRange(notificationMessage.Document.ContentStart, notificationMessage.Document.ContentEnd);
                UserNotifications newNotify = new UserNotifications()
                {
                    User_ID = 211818414,
                    Body = text.Text
                };

                dbContext.AddRange(newNotify);
                dbContext.SaveChanges();
            }

            usersDataGrid.Visibility = Visibility.Visible;
            notificationView.Visibility = Visibility.Hidden;
            notifyViewBorder.Visibility = Visibility.Hidden;
            addPlanView.Visibility = Visibility.Hidden;
            planViewBorder.Visibility = Visibility.Hidden;
            messagesView.Visibility = Visibility.Hidden;
            messagesViewBorder.Visibility = Visibility.Hidden;

            MessageBox.Show("Successfully send notification");
        }

        private void btnCancelNotify_Click(object sender, RoutedEventArgs e)
        {
            usersDataGrid.Visibility = Visibility.Visible;
            notificationView.Visibility = Visibility.Hidden;
            notifyViewBorder.Visibility = Visibility.Hidden;
            addPlanView.Visibility = Visibility.Hidden;
            planViewBorder.Visibility = Visibility.Hidden;
            messagesView.Visibility = Visibility.Hidden;
            messagesViewBorder.Visibility = Visibility.Hidden;
        }

        private void idText_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out int result);
        }

        private void idTextModify_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out int result);
        }

        private void btnRemoveUserFromSystem_Click(object sender, RoutedEventArgs e)
        {
            using(var dbContext = new DatabaseGYM())
            {
                if(dbContext.Users.Where(p => p.User_ID == int.Parse(idTextModify.Text)).Any())
                {
                    var user = dbContext.Users.FirstOrDefault(p => p.User_ID == int.Parse(idTextModify.Text));
                    foreach (Messages message in dbContext.AdminMessages)
                    {
                        if (dbContext.AdminMessages.Where(p => p._From_ID == int.Parse(idTextModify.Text)).Any())
                            dbContext.Remove(message);
                    }
                    foreach (UsersCalendar schedule in dbContext.UserCalendar)
                    {
                        if(dbContext.UserCalendar.Where(p => p.User_ID == int.Parse(idTextModify.Text)).Any())
                        {
                            dbContext.Remove(schedule);
                        }
                    }
                    foreach (UserNotifications notification in dbContext.UserNotifications)
                    {
                        if (dbContext.UserNotifications.Where(p => p.User_ID == int.Parse(idTextModify.Text)).Any())
                        {
                            dbContext.Remove(notification);
                        }
                    }
                    dbContext.Remove(user);
                    dbContext.SaveChanges();

                    MessageBox.Show("Successfully removed user");
                }
                else
                {
                    MessageBox.Show("No such user");
                }
            }

            using (var dbContext = new DatabaseGYM())
            {
                var users = from User in dbContext.Users
                            select User;

                usersDataGrid.ItemsSource = users.ToList();
            }
        }

        private void btnDisplayVIPUsers_Click(object sender, RoutedEventArgs e)
        {
            addPlanView.Visibility = Visibility.Hidden;
            usersDataGrid.Visibility = Visibility.Visible;
            planViewBorder.Visibility = Visibility.Hidden;
            notificationView.Visibility = Visibility.Hidden;
            notifyViewBorder.Visibility = Visibility.Hidden;
            messagesView.Visibility = Visibility.Hidden;
            messagesViewBorder.Visibility = Visibility.Hidden;

            using (var dbContext = new DatabaseGYM())
            {
                var vip = from User in dbContext.Users
                          join Plan in dbContext.Plans
                          on User.Plan_ID equals Plan.Plan_ID
                          select new
                          {
                              FullName = User.FirstName + " " + User.LastName,
                              User_ID = User.User_ID,
                              Plan = Plan._Plan
                          };

                usersDataGrid.ItemsSource = vip.ToList();
            }
        }

        private void btnCancelPlan_Click(object sender, RoutedEventArgs e)
        {
            addPlanView.Visibility = Visibility.Hidden;
            usersDataGrid.Visibility = Visibility.Visible;
            planViewBorder.Visibility = Visibility.Hidden;
            notificationView.Visibility = Visibility.Hidden;
            notifyViewBorder.Visibility = Visibility.Hidden;
            messagesView.Visibility = Visibility.Hidden;
            messagesViewBorder.Visibility = Visibility.Hidden;
        }

        private void btnCreatePlan_Click(object sender, RoutedEventArgs e)
        {
            if (planName.Text != "" && planCost.Text != "")
            {
                using (var dbContext = new DatabaseGYM())
                {
                    Plans plan = new Plans()
                    {
                        _Plan = planName.Text,
                        Cost = int.Parse(planCost.Text)
                    };

                    dbContext.AddRange(plan);
                    dbContext.SaveChanges();

                    addPlanView.Visibility = Visibility.Hidden;
                    usersDataGrid.Visibility = Visibility.Visible;
                    planViewBorder.Visibility = Visibility.Hidden;
                    notificationView.Visibility = Visibility.Hidden;
                    notifyViewBorder.Visibility = Visibility.Hidden;
                    messagesView.Visibility = Visibility.Hidden;
                    messagesViewBorder.Visibility = Visibility.Hidden;

                    MessageBox.Show("Successfully added new plan");
                }
            }
            else
            {
                MessageBox.Show("Please don't leave empty slots!");
            }
        }

        private void btnAddNewPlan_Click(object sender, RoutedEventArgs e)
        {
            addPlanView.Visibility = Visibility.Visible;
            usersDataGrid.Visibility = Visibility.Hidden;
            planViewBorder.Visibility = Visibility.Visible;
            notificationView.Visibility = Visibility.Hidden;
            notifyViewBorder.Visibility = Visibility.Hidden;
            messagesView.Visibility = Visibility.Hidden;
            messagesViewBorder.Visibility = Visibility.Hidden;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            using (var dbContext = new DatabaseGYM())
            {
                List<Messages> msgArr = new List<Messages>();

                foreach (Messages message in dbContext.AdminMessages)
                {
                    msgArr.Add(message);
                }

                index = 0;

                if(dbContext.AdminMessages.Where(p => p.Message_ID != 0).Any())
                {
                    addPlanView.Visibility = Visibility.Hidden;
                    usersDataGrid.Visibility = Visibility.Hidden;
                    planViewBorder.Visibility = Visibility.Hidden;
                    notificationView.Visibility = Visibility.Hidden;
                    notifyViewBorder.Visibility = Visibility.Hidden;
                    messagesView.Visibility = Visibility.Visible;
                    messagesViewBorder.Visibility = Visibility.Visible;

                    var user = dbContext.Users.FirstOrDefault(p => p.User_ID == msgArr[index]._From_ID);

                    msgFrom.Text = user.FirstName + " " + user.LastName;
                    msgBody.Text = msgArr[index].Body;
                }
                else
                {
                    addPlanView.Visibility = Visibility.Hidden;
                    usersDataGrid.Visibility = Visibility.Visible;
                    planViewBorder.Visibility = Visibility.Hidden;
                    notificationView.Visibility = Visibility.Hidden;
                    notifyViewBorder.Visibility = Visibility.Hidden;
                    messagesView.Visibility = Visibility.Hidden;
                    messagesViewBorder.Visibility = Visibility.Hidden;
                    MessageBox.Show("No new messages...");
                }
            }
        }

        private void btnNextMsg_Click(object sender, RoutedEventArgs e)
        {
            using (var dbContext = new DatabaseGYM())
            {
                List<Messages> msgArr = new List<Messages>();

                foreach (Messages message in dbContext.AdminMessages)
                {
                    msgArr.Add(message);
                }

                if(index + 1 < msgArr.Count)
                {
                    index++;

                    var user = dbContext.Users.FirstOrDefault(p => p.User_ID == msgArr[index]._From_ID);

                    msgFrom.Text = user.FirstName + " " + user.LastName;
                    msgBody.Text = msgArr[index].Body;
                }
                else
                {
                    MessageBox.Show("No more messages found");
                }
            }
        }

        private void btnPreviousMsg_Click(object sender, RoutedEventArgs e)
        {
            using (var dbContext = new DatabaseGYM())
            {
                List<Messages> msgArr = new List<Messages>();

                foreach (Messages message in dbContext.AdminMessages)
                {
                    msgArr.Add(message);
                }

                if (index != 0)
                {
                    index--;

                    var user = dbContext.Users.FirstOrDefault(p => p.User_ID == msgArr[index]._From_ID);

                    msgFrom.Text = user.FirstName + " " + user.LastName;
                    msgBody.Text = msgArr[index].Body;
                }
                else
                {
                    MessageBox.Show("This is the last message");
                }
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            MainUI main = new MainUI();
            main.Show();
            main.ShowDisplay();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            using (var dbContext = new DatabaseGYM())
            {
                if(dbContext.AdminMessages.Where(p => p.Message_ID == 1).Any())
                {
                    foreach (Messages messages in dbContext.AdminMessages)
                    {
                        dbContext.Remove(messages);
                    }

                    MessageBox.Show("Successfully deleted all messages!");
                }
                else
                {
                    MessageBox.Show("There are no messages to delete!");
                }

                dbContext.SaveChanges();
            }
        }
    }
}
