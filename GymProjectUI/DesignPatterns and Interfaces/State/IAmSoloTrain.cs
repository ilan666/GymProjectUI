using GYMDatabaseProject.DataAccess;
using GYMDatabaseProject.Models;
using GymProjectUI.DesignPatterns_and_Interfaces.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GymProjectUI
{
    public class IAmSoloTrain : ICalendarState
    {

        public ICalendarState SetSoloTrain()
        {
            MessageBox.Show("This cell is already taken!\nFree up the space to use it.");
            return this;
        }

        public ICalendarState SetPersonalTrainerTrain()
        {
            MessageBox.Show("This cell is already taken!\nFree up the space to use it.");
            return this;
        }

        public ICalendarState FreeSchedule()
        {
            return new IAmFree();
        }
    }
}
