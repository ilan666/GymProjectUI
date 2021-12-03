using GYMDatabaseProject.DataAccess;
using GYMDatabaseProject.Models;
using GymProjectUI.DesignPatterns_and_Interfaces.State;
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

namespace GymProjectUI.WPF_APPS
{
    /// <summary>
    /// Interaction logic for Calendar.xaml
    /// </summary>
    public partial class Calendar : Window
    {

        public Calendar()
        {
            InitializeComponent();

            foreach (var textblock in calendarGrid.Children.OfType<TextBlock>())
            {
                foreach (var utilTextblock in Utilities.Utilities.SoloCalendarCache)
                {
                    var row1 = Grid.GetRow(textblock);
                    var column1 = Grid.GetColumn(textblock);

                    var row2 = Grid.GetRow(utilTextblock);
                    var column2 = Grid.GetColumn(utilTextblock);
                    if (row1 == row2 && column1 == column2)
                    {
                        textblock.Background = Brushes.Green;
                    }
                }
            }

            foreach (var textblock in calendarGrid.Children.OfType<TextBlock>())
            {
                foreach (var utilTextblock in Utilities.Utilities.PersonalTrainerCalendarCache)
                {
                    var row1 = Grid.GetRow(textblock);
                    var column1 = Grid.GetColumn(textblock);

                    var row2 = Grid.GetRow(utilTextblock);
                    var column2 = Grid.GetColumn(utilTextblock);
                    if (row1 == row2 && column1 == column2)
                    {
                        textblock.Background = Brushes.Yellow;
                        textblock.Text = utilTextblock.Text;
                        textblock.TextAlignment = TextAlignment.Center;
                    }
                }
            }

            foreach (var textblock in calendarGrid.Children.OfType<TextBlock>())
            {
                foreach (var utilTextblock in Utilities.Utilities.FreePlanCalendarCache)
                {
                    var row1 = Grid.GetRow(textblock);
                    var column1 = Grid.GetColumn(textblock);

                    var row2 = Grid.GetRow(utilTextblock);
                    var column2 = Grid.GetColumn(utilTextblock);
                    if (row1 == row2 && column1 == column2)
                    {
                        textblock.Background = null;
                    }
                }
            }
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock currentPick = sender as TextBlock;

            string dayText = "";
            DateTime time = default;

            List<TextBlock> days = new List<TextBlock>()
            {
                sunday,
                monday,
                thursday,
                wednesday,
                thusday,
                friday,
                satureday
            };

            List<TextBlock> times = new List<TextBlock>()
            {
                time800,
                time900,
                time1000,
                time1100,
                time1200,
                time1300,
                time1400,
                time1500,
                time1600,
                time1700,
                time1800,
                time1900,
                time2000,
                time2100,
                time2200,
                time2300,
                time2400,
            };

            if ((bool)radioSoloTrain.IsChecked)
            {
                foreach (TextBlock day in days)
                {
                    if (Grid.GetColumn(currentPick) == Grid.GetColumn(day))
                    {
                        dayText = day.Text;
                        break;
                    }
                }

                foreach (TextBlock _time in times)
                {
                    if (Grid.GetRow(currentPick) == Grid.GetRow(_time))
                    {
                        time = Convert.ToDateTime(_time.Text);
                        break;
                    }
                }

                Utilities.Utilities.Day = dayText;
                Utilities.Utilities.time = time;

                if (Grid.GetColumn(currentPick) != 0 && Grid.GetRow(currentPick) != 0)
                {
                    Context context = new Context(null);

                    if (currentPick.Background == null)
                    {
                        context = new Context(new IAmFree());
                    }
                    else if (currentPick.Background == Brushes.Green)
                    {
                        context = new Context(new IAmSoloTrain());
                    }
                    else if (currentPick.Background == Brushes.Yellow)
                    {
                        context = new Context(new IAmPersonalTrainerTrain());
                    }
                    else if (currentPick.Background == Brushes.Purple)
                    {
                        MessageBox.Show("This is a permanent event!\nYou can't change it.");
                    }

                    Utilities.Utilities.CurrentPick = currentPick;

                    context.RequestPlaceSoloTrain();

                    currentPick.Background = Utilities.Utilities.CurrentPick.Background;

                    Utilities.Utilities.SoloCalendarCache.Add(currentPick);
                }
            }

            else if ((bool)radioTrainerTrain.IsChecked)
            {
                foreach (TextBlock day in days)
                {
                    if (Grid.GetColumn(currentPick) == Grid.GetColumn(day))
                    {
                        dayText = day.Text;
                        break;
                    }
                }

                foreach (TextBlock _time in times)
                {
                    if (Grid.GetRow(currentPick) == Grid.GetRow(_time))
                    {
                        time = Convert.ToDateTime(_time.Text);
                        break;
                    }
                }

                Utilities.Utilities.Day = dayText;
                Utilities.Utilities.time = time;


                if (Grid.GetColumn(currentPick) != 0 && Grid.GetRow(currentPick) != 0)
                {
                    Context context = new Context(null);

                    if (currentPick.Background == null)
                    {
                        context = new Context(new IAmFree());
                    }
                    else if (currentPick.Background == Brushes.Green)
                    {
                        context = new Context(new IAmSoloTrain());
                    }
                    else if (currentPick.Background == Brushes.Yellow)
                    {
                        context = new Context(new IAmPersonalTrainerTrain());
                    }
                    else if (currentPick.Background == Brushes.Purple)
                    {
                        MessageBox.Show("This is a permanent event!\nYou can't change it.");
                    }

                    Utilities.Utilities.CurrentPick = currentPick;

                    context.RequestPlaceTrainerTrain();

                    currentPick.Background = Utilities.Utilities.CurrentPick.Background;

                    Utilities.Utilities.PersonalTrainerCalendarCache.Add(currentPick);
                }
            }

            if ((bool)radioFreeSpace.IsChecked)
            {
                if (Grid.GetColumn(currentPick) != 0 && Grid.GetRow(currentPick) != 0)
                {
                    Context context = new Context(new IAmFree());

                    Utilities.Utilities.CurrentPick = currentPick;

                    context.RequestFreePlan();

                    currentPick.Background = Utilities.Utilities.CurrentPick.Background;

                    currentPick.Text = "";

                    Utilities.Utilities.FreePlanCalendarCache.Add(currentPick);
                }
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            MainUI main = new MainUI();
            main.Show();
            main.ShowDisplay();
            this.Hide();
        }
    }
}
