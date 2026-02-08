using System;
using System.Collections.Generic;
using System.Text;

namespace GymTrackerApp.MVVM.Models
{
    class Exercise
    {
        public string ExerciseName { get; set; } = "";
        public string RepsOrTime { get; set; } = "0";
        public string Weight { get; set; } = "0";
    }
}
