using GYMDatabaseProject.DataAccess;
using GYMDatabaseProject.Models;
using GymProjectUI.WPF_APPS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GymProjectUI.DesignPatterns_and_Interfaces.State
{
    public class IAmFree : ICalendarState
    {
        public ICalendarState SetPersonalTrainerTrain()
        {
            Calendar cal = new Calendar();

            using (var dbContext = new DatabaseGYM())
            {
                var user = dbContext.Users.FirstOrDefault(p => p.User_ID == Utilities.Utilities.User.User_ID);

                UsersCalendar userCal = new UsersCalendar()
                {
                    User_ID = Utilities.Utilities.User.User_ID,
                    Type = "Personal trainer excersice",
                    Day = Utilities.Utilities.Day,
                    Time = Utilities.Utilities.time
                };

                user.Schedules.Add(userCal);

                dbContext.AddRange(userCal);
                dbContext.SaveChanges();
            }

            Utilities.Utilities.CurrentPick.Background = Brushes.Yellow;
            Utilities.Utilities.CurrentPick.Text = Utilities.Utilities.TrainerName;
            Utilities.Utilities.CurrentPick.TextAlignment = System.Windows.TextAlignment.Center;

            return new IAmPersonalTrainerTrain();
        }

        public ICalendarState SetSoloTrain()
        {
            Calendar cal = new Calendar();

            using (var dbContext = new DatabaseGYM())
            {
                UsersCalendar userCal = new UsersCalendar()
                {
                    User_ID = Utilities.Utilities.User.User_ID,
                    Type = "Solo Excersice",
                    Day = Utilities.Utilities.Day,
                    Time = Utilities.Utilities.time
                };

                dbContext.AddRange(userCal);
                dbContext.SaveChanges();
            }

            Utilities.Utilities.CurrentPick.Background = Brushes.Green;

            return new IAmSoloTrain();
        }

        public ICalendarState FreeSchedule()
        {
            Calendar cal = new Calendar();

            Utilities.Utilities.CurrentPick.Background = null;

            return this;
        }
    }
}
