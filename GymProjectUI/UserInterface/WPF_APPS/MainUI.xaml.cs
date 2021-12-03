using GYMDatabaseProject.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using GymProjectUI.Utilities;
using GymProjectUI.UserInterface.WPF_APPS;
using System.IO;

namespace GymProjectUI.WPF_APPS
{
    /// <summary>
    /// Interaction logic for MainUI.xaml
    /// </summary>
    public partial class MainUI : Window
    {
        public int User_ID { get; set; }

        public int ImageIndexer { get; set; }

        DispatcherTimer timer = new DispatcherTimer();

        public MainUI()
        {
            InitializeComponent();
        }

        // Open up the plans store window // WPF_APPS > PlansUI.xaml > PlansUI.xmal.cs //
        private void btnBuyNewPlan_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            PlansUI plansWindow = new PlansUI();
            plansWindow.Show();
            this.Close();
        }
        /////////////////////////////////////////////////////////////////////////////////

        // This method os to pass the ID data from the login window so THIS window could
        // Recognize the user and use thr data to display the window
        // ShowDisplay() Method uses the validation of the ID data and displays the content.
        //public void PassIDData(int id)
        //{
        //    User_ID = id;
        //}
        /////////////////////////////////////////////////////////////////////////////////

        // The Display method that uses the ID Data passed from login window //
        public void ShowDisplay()
        {
            timer.Interval = TimeSpan.FromSeconds(2);

            using (var dbContext = new DatabaseGYM())
            {
                name.Text = Utilities.Utilities.User.FirstName + " " + Utilities.Utilities.User.LastName;

                if(dbContext.Plans.Where(p => p.Plan_ID == Utilities.Utilities.User.Plan_ID).Any())
                {
                    var plan = dbContext.Plans.FirstOrDefault(p => p.Plan_ID == Utilities.Utilities.User.Plan_ID);
                    subscription.Text = plan._Plan.ToString();
                    expireDatePlan.Text = Utilities.Utilities.User.PlanExpiration.ToShortDateString();
                }
                else subscription.Text = "No Current Plan";

                if (dbContext.UserNotifications.Where(p => p.User_ID == Utilities.Utilities.User.User_ID).Any())
                {
                    var notification = dbContext.UserNotifications.FirstOrDefault(p => p.User_ID == Utilities.Utilities.User.User_ID);
                    notifications.Text = notification.Body;
                }
                else notifications.Text = "You don't have any notifications yet...";
            }

            this.date.Text = DateTime.Now.Date.ToShortDateString();

            trainersList.SelectedIndex = 0;

            timer.Tick += ChangeImage;
            timer.Start();
        }
        /////////////////////////////////////////////////////////////////////////////////

        private void trainersList_DropDownClosed(object sender, EventArgs e)
        {
            switch (trainersList.SelectedIndex)
            {
                case 1:
                    trainerIMG.Source = new BitmapImage(new Uri("/UserInterface/Images/Trainer1.jpg", UriKind.Relative));
                    trainerDesc.Text = "It wasn’t long before he was working out regularly,\n" +
                        "as he was inspired by other people getting into\n" +
                        "great shape and determined to have a physique\n" +
                        "that he could be proud of.";
                    this.Show();
                    break;

                case 2:
                    trainerIMG.Source = new BitmapImage(new Uri("/UserInterface/Images/Trainer2.jpg", UriKind.Relative));
                    trainerDesc.Text = "He’s been dubbed the model whisperer by the \n" +
                        "New York Times, because of his expertise in training\n" +
                        "models to be in the best shape possible for \n" +
                        "their careers.";
                    this.Show();
                    break;

                case 3:
                    trainerIMG.Source = new BitmapImage(new Uri("/UserInterface/Images/Trainer3.jpg", UriKind.Relative));
                    trainerDesc.Text = "Going from being a PT and\n" +
                        "a competitive physique athlete\n" +
                        "to the CEO of a major fitness brand is pretty impressive\n" +
                        "and certainly qualifies you to join the ranks of \n" +
                        "celebrity personal trainers in the UK!";
                    this.Show();
                    break;

                case 4:
                    trainerIMG.Source = new BitmapImage(new Uri("/UserInterface/Images/Trainer4.jpg", UriKind.Relative));
                    trainerDesc.Text = "Scrolling through her feed, you’ll find that she\n" +
                        "tries to switch up her routines, using a large \n" +
                        "variety of equipment. Think about the most unusual\n" +
                        "exercises you have seen… Alexia Clark has probably \n" +
                        "posted about them already.";
                    this.Show();
                    break;

                case 5:
                    trainerIMG.Source = new BitmapImage(new Uri("/UserInterface/Images/Trainer5.jpg", UriKind.Relative));
                    trainerDesc.Text = "If you are an avid follower of social media,\n" +
                        "then you’ve more than likely come across any\n" +
                        "number of meme comparisons, showing how The Rock\n" +
                        "looked before and after he was trained\n" +
                        "by Aaron Williamson.";
                    this.Show();
                    break;

                case 6:
                    trainerIMG.Source = new BitmapImage(new Uri("/UserInterface/Images/Trainer7.jpg", UriKind.Relative));
                    trainerDesc.Text = "In the past, she has worked with big names \n" +
                        "including P!nk, Alicia Keys, Tia Mowry, Amber Rose,\n" +
                        " Tracee Ellis Ross, Nia Long, Kelly Rowland,\n" +
                        " Serena Williams, and Shonda Rhimes.";
                    this.Show();
                    break;

                case 7:
                    trainerIMG.Source = new BitmapImage(new Uri("/UserInterface/Images/Trainer6.jpg", UriKind.Relative));
                    trainerDesc.Text = "He posts a whole host of fitness content and\n" +
                        "has worked with a number of athletes during their \n" +
                        "competition preparation. One of his clients includes\n" +
                        "Mike Worsley, who started training with Shaun after\n" +
                        "he finished playing international rugby!";
                    this.Show();
                    break;
            }
        }

        private void ChangeImage(object sender, EventArgs e)
        {
            ImageIndexer++;
            switch (ImageIndexer)
            {
                case 1:
                    newPNG.Source = new BitmapImage(new Uri("/UserInterface/Images/GymNews1.jpg", UriKind.Relative));
                    newsText.Text = "Reach out to fitness\n" +
                        "brands in the food\n" +
                        "industry, especially\n" +
                        "those looking to\n" +
                        "expand their market";
                    this.Show();
                    break;

                case 2:
                    newPNG.Source = new BitmapImage(new Uri("/UserInterface/Images/GymNews2.jpg", UriKind.Relative));
                    newsText.Text = "Not everything needs \n" +
                        "to be about fitness. \n" +
                        "Give back to the \n" +
                        "community, and define \n" +
                        "your brand as a gym \n" +
                        "that cares.";
                    this.Show();
                    break;

                case 3:
                    newPNG.Source = new BitmapImage(new Uri("/UserInterface/Images/GymNews3.jpg", UriKind.Relative));
                    newsText.Text = "Make it a family\n" +
                        "affair and invite\n" +
                        "family members to come\n" +
                        "out and do group \n" +
                        "workout sessions \n" +
                        "separate or together.";
                    this.Show();
                    break;

                case 4:
                    newPNG.Source = new BitmapImage(new Uri("/UserInterface/Images/GymNews4.jpg", UriKind.Relative));
                    newsText.Text = "Take an educational \n" +
                        "approach and host \n" +
                        "a fitness trainer workshop \n" +
                        "at your gym; this \n" +
                        "event works best";
                    this.Show();
                    ImageIndexer = 0;
                    break;
            }
        }

        private void btnCalendar_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            Calendar calendar = new Calendar();
            calendar.Show();
            this.Close();
        }

        private void btnPlaneTrainerCal_Click(object sender, RoutedEventArgs e)
        {
            if (trainersList.SelectedIndex != 0)
            {
                timer.Stop();
                Calendar calendar = new Calendar();
                calendar.Show();
                calendar.radioSoloTrain.IsEnabled = false;
                calendar.radioTrainerTrain.IsChecked = true;
                MessageBox.Show("You only need to choose the\n" +
                    "Desired schedule.\n" +
                    "Free up plans if needed but don't\n" +
                    "Forget to select the Personal train\n" +
                    "button!");
                Utilities.Utilities.TrainerName = trainersList.Text;
                this.Close();
            }
            else
            {
                trainerDesc.Text = "Must select a trainer to do that!";
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            ExitProgram exit = new ExitProgram();
            timer.Stop();
            exit.Show();
        }

        private void btnPersonalSettings_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            PersonalSettings personalSettings = new PersonalSettings();
            personalSettings.Show();
            this.Close();
        }

        private void btnContact_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            ContactAdmin contact = new ContactAdmin();
            contact.Show();
            this.Close();
        }

        private void btnAdminLogin_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            MessageBox.Show("You're automatically an admin since you're\n" +
                "the project tester");
            AdminControl adminControl = new AdminControl();
            adminControl.Show();
            this.Close();
        }
    }
}
