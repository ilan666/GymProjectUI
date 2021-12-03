using GYMDatabaseProject.Models;
using GymProjectUI.DesignPatterns_and_Interfaces.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GymProjectUI.Utilities
{
    public static class Utilities
    {
        public static Users User { get; set; }

        public static List<TextBlock> SoloCalendarCache = new List<TextBlock>();

        public static List<TextBlock> PersonalTrainerCalendarCache = new List<TextBlock>();

        public static List<TextBlock> FreePlanCalendarCache = new List<TextBlock>();

        public static TextBlock CurrentPick { get; set; }

        public static DateTime time { get; set; }

        public static string Day { get; set; }

        public static Context CurrentContext { get; set; }

        public static string TrainerName { get; set; }
    }
}
