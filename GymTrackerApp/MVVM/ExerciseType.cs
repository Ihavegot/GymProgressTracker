using System.ComponentModel;

namespace GymTrackerApp.MVVM
{
    public enum ExerciseType
    {
        [Description("Multiple parts")]
        FBW,

        [Description("Chest exercise")]
        Chest,

        [Description("Back exercise")]
        Back,

        [Description("Leg exercise")]
        Legs,

        [Description("Shoulder exercise")]
        Shoulders
    }
}
