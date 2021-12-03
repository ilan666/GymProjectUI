using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymProjectUI.DesignPatterns_and_Interfaces.State
{
    public class Context
    {
        private ICalendarState state;

        public Context(ICalendarState state)
        {
            this.state = state;
        }

        public void RequestPlaceSoloTrain()
        {
            this.state = this.state.SetSoloTrain();
        }

        public void RequestPlaceTrainerTrain()
        {
            this.state = this.state.SetPersonalTrainerTrain();
        }

        public void RequestFreePlan()
        {
            this.state = this.state.FreeSchedule();
        }
    }
}
