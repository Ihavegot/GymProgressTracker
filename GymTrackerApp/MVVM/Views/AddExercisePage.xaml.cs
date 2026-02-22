using GymTrackerApp.MVVM.Models;
using GymTrackerApp.MVVM.Services;
using GymTrackerApp.MVVM.ViewModels;
using Microsoft.Maui.Controls;

namespace GymTrackerApp.MVVM.Views
{
    public partial class AddExercisePage : ContentPage
    {
        private readonly ExerciseStorageService _exerciseService;

        public AddExercisePage()
        {
            InitializeComponent();
            _exerciseService = new ExerciseStorageService();
            BindingContext = new ExerciseTypeViewModel();
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ExerciseNameEntry.Text))
                {
                    await DisplayAlert("Validation", "Please enter an exercise name", "OK");
                    return;
                }

                var exercise = new Exercise
                {
                    Id = Guid.NewGuid().ToString(),
                    ExerciseName = ExerciseNameEntry.Text,
                    RepsOrTime = RepsOrTimeEntry.Text ?? string.Empty,
                    Weight = WeightEntry.Text ?? string.Empty
                };

                await _exerciseService.Write(exercise);
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to save exercise: {ex.Message}", "OK");
            }
        }
    }
}