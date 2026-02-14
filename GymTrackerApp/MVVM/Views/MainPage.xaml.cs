using GymTrackerApp.MVVM.Models;
using GymTrackerApp.MVVM.Services;
using GymTrackerApp.MVVM.Views;
using System.Text.Json;

namespace GymTrackerApp
{
    public partial class MainPage : ContentPage
    {
        private readonly ExerciseStorageService _exerciseService;
        public MainPage()
        {
            InitializeComponent();
            _exerciseService = new ExerciseStorageService();
            LoadExercises();
        }

        private async void OnNavigateClicked(object sender, EventArgs e)
        {
            // TODO: Fix navigation to AddExercisePage
            await Shell.Current.GoToAsync(nameof(AddExercisePage));
        }


        private async void LoadExercises()
        {
            try
            {
                var data = await _exerciseService.Read();
                ProductsView.ItemsSource = data;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to load exercises: {ex.Message}", "OK");
            }
        }

        public async void ReadData()
        {
            var execrise = new MVVM.Services.ExerciseStorageService();
            var data = await execrise.Read();
            ProductsView.ItemsSource = data;
        }

        //public async void SaveData(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (string.IsNullOrWhiteSpace(exerciseNameEntry.Text))
        //        {
        //            await DisplayAlertAsync("Validation", "Please enter an exercise name", "OK");
        //            return;
        //        }

        //        var exercise = new Exercise
        //        {
        //            ExerciseName = exerciseNameEntry.Text,
        //            RepsOrTime = repsOrTimeEntry.Text,
        //            Weight = weightEntry.Text
        //        };

        //        await _exerciseService.Write(exercise);

        //        exerciseNameEntry.Text = string.Empty;
        //        repsOrTimeEntry.Text = string.Empty;
        //        weightEntry.Text = string.Empty;

        //        LoadExercises();
        //    }
        //    catch (Exception ex)
        //    {
        //        await DisplayAlertAsync("Error", $"Failed to save exercise: {ex.Message}", "OK");
        //    }
        //}

        public async void DeleteData(object sender, EventArgs e)
        {
            try
            {
                var button = sender as Button;
                var exercise = button?.CommandParameter as Exercise;

                if (exercise == null)
                    return;

                bool confirmed = await DisplayAlert("Confirm", "Delete this exercise?", "Yes", "No");
                if (confirmed)
                {
                    await _exerciseService.Delete(exercise.Id);
                    LoadExercises();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to delete exercise: {ex.Message}", "OK");
            }
        }
    }
}
