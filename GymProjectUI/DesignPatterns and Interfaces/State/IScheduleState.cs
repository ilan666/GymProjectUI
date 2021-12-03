using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymProjectUI
{
    public interface ICalendarState
    {
        ICalendarState SetSoloTrain();

        ICalendarState SetPersonalTrainerTrain();

        ICalendarState FreeSchedule();
    }
}
