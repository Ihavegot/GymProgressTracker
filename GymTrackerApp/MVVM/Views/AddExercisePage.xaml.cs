using Microsoft.Maui.Controls;

namespace GymTrackerApp.MVVM.Views
{
    public partial class AddExercisePage : ContentView
    {
        public AddExercisePage()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AddExercisePage), typeof(AddExercisePage));
        }
    }
}