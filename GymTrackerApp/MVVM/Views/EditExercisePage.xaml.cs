using GymTrackerApp.MVVM.Models;
using GymTrackerApp.MVVM.Services;
using Microsoft.Maui.Controls;

namespace GymTrackerApp.MVVM.Views
{
    [QueryProperty(nameof(ExerciseId), "id")]
    public partial class EditExercisePage : ContentPage
    {
        private readonly ExerciseStorageService _exerciseService;
        private string? _exerciseId;
        private Exercise? _currentExercise;

        public string? ExerciseId
        {
            get => _exerciseId;
            set
            {
                _exerciseId = value;
                LoadExercise();
            }
        }

        public EditExercisePage()
        {
            InitializeComponent();
            _exerciseService = new ExerciseStorageService();
        }

        private async void LoadExercise()
        {
            try
            {
                var exercises = await _exerciseService.Read();
                _currentExercise = exercises.FirstOrDefault(e => e.Id == _exerciseId);

                if (_currentExercise != null)
                {
                    ExerciseNameEntry.Text = _currentExercise.ExerciseName;
                    RepsOrTimeEntry.Text = _currentExercise.RepsOrTime;
                    WeightEntry.Text = _currentExercise.Weight;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to load exercise: {ex.Message}", "OK");
            }
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

                if (_currentExercise == null)
                {
                    await DisplayAlert("Error", "Exercise not found", "OK");
                    return;
                }

                _currentExercise.ExerciseName = ExerciseNameEntry.Text;
                _currentExercise.RepsOrTime = RepsOrTimeEntry.Text ?? string.Empty;
                _currentExercise.Weight = WeightEntry.Text ?? string.Empty;

                await _exerciseService.Update(_currentExercise);
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to update exercise: {ex.Message}", "OK");
            }
        }
    }
}