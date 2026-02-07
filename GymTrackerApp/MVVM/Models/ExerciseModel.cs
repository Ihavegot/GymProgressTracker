using System;
using System.Collections.Generic;
using System.Text;

namespace GymTrackerApp.MVVM.Models
{
    class ExerciseModel
    {
        public string ExerciseName { get; set; } = string.Empty;
        public string RepsOrTime { get; set; } = "0";
        public string Weight { get; set; } = "0";
    }
}
