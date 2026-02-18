using GymTrackerApp.MVVM.Models;
using GymTrackerApp.MVVM.Services;
using GymTrackerApp.MVVM.Views;

namespace GymTrackerApp
{
    public partial class MainPage : ContentPage
    {
        private readonly ExerciseStorageService _exerciseService;
        public MainPage()
        {
            InitializeComponent();
            _exerciseService = new ExerciseStorageService();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadExercises();
        }

        private async void OnNavigateClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(AddExercisePage));
        }

        private async void OnExerciseTapped(object sender, EventArgs e)
        {
            try
            {
                var gesture = sender as Element;
                var exercise = gesture?.BindingContext as Exercise;

                if (exercise == null)
                    return;

                await Shell.Current.GoToAsync($"{nameof(EditExercisePage)}?id={exercise.Id}");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to navigate to edit page: {ex.Message}", "OK");
            }
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
