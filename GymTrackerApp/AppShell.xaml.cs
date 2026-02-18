using GymTrackerApp.MVVM.Views;

namespace GymTrackerApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AddExercisePage), typeof(AddExercisePage));
            Routing.RegisterRoute(nameof(EditExercisePage), typeof(EditExercisePage));
        }
    }
}
