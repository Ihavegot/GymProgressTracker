using GymTrackerApp.MVVM.Models;
using System.Text.Json;

namespace GymTrackerApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            ReadData();
        }

        public async void ReadData()
        {
            var execrise = new MVVM.Services.ExerciseStorageService();
            var data = await execrise.Read();
            ProductsView.ItemsSource = data;
        }

        public async void SaveData(object sender, EventArgs e)
        {
            var execrise = new MVVM.Services.ExerciseStorageService();
            var data = new Exercise
            {
                ExerciseName = exerciseNameEntry.Text,
                RepsOrTime = repsOrTimeEntry.Text,
                Weight = weightEntry.Text
            };
            await execrise.Write(data);
            ReadData();
        }

        public async void DeleteData(object sender, EventArgs e)
        {
            var execrise = new MVVM.Services.ExerciseStorageService();
            var data = await execrise.Read();

            var button = sender as Button;
            var exerciseButton = button?.CommandParameter as Exercise;

            if (exerciseButton == null)
            {
                return;
            }

            await execrise.Delete(exerciseButton.Id);
            ReadData();
        }
    }
}
