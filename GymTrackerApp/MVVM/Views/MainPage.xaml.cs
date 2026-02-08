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

            exerciseNameOutput.Text = data.ExerciseName;
            repsOrTimeOutput.Text = data.RepsOrTime;
            weightOutput.Text = data.Weight;

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
    }
}
