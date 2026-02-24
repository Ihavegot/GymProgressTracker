using GymTrackerApp.MVVM;
using GymTrackerApp.MVVM.Models;
using GymTrackerApp.MVVM.Services;
using GymTrackerApp.MVVM.ViewModels;
using GymTrackerApp.MVVM.Views;

namespace GymTrackerApp
{
    public partial class MainPage : ContentPage
    {
        private readonly ExerciseStorageService _exerciseService;
        private readonly MainViewModel _viewModel;
        public MainPage()
        {
            InitializeComponent();
            _exerciseService = new ExerciseStorageService();
            _viewModel = new MainViewModel();
            BindingContext = _viewModel;
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
                _viewModel.LoadExercises(data);
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

        #region Filters

        private void UpdateButtonStyles(Button selectedButton)
        {
            var resources = Application.Current?.Resources;
            if (resources == null)
                return;

            if (resources.TryGetValue("PrimaryWithAlpha20", out var primaryWithAlpha20) &&
                resources.TryGetValue("Primary", out var primary) && 
                resources.TryGetValue("AppBackgroundColor", out var appBackgroundColor))
            {
                AllButton.BackgroundColor = (Color)primaryWithAlpha20;
                AllButton.TextColor = (Color)primary;

                ChestButton.BackgroundColor = (Color)primaryWithAlpha20;
                ChestButton.TextColor = (Color)primary;

                BackButton.BackgroundColor = (Color)primaryWithAlpha20;
                BackButton.TextColor = (Color)primary;

                LegsButton.BackgroundColor = (Color)primaryWithAlpha20;
                LegsButton.TextColor = (Color)primary;

                selectedButton.BackgroundColor = (Color)primary;
                selectedButton.TextColor = (Color)appBackgroundColor;
            }
        }

        private void OnFilterChest(object sender, EventArgs e)
        {
            UpdateButtonStyles(ChestButton);
            _viewModel.FilterByType(ExerciseType.Chest);
        }
        private void OnFilterLegs(object sender, EventArgs e)
        {
            UpdateButtonStyles(LegsButton);
            _viewModel.FilterByType(ExerciseType.Legs);
        }
        private void OnFilterBack(object sender, EventArgs e)
        {
            UpdateButtonStyles(BackButton);
            _viewModel.FilterByType(ExerciseType.Back);
        }
        private void OnFilterAll(object sender, EventArgs e)
        {
            UpdateButtonStyles(AllButton);
            _viewModel.ClearFilter();
        }

        #endregion
    }
}
