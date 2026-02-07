using GymTrackerApp.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace GymTrackerApp.MVVM.Services
{
    class JsonRead
    {
        public static async Task<List<ExerciseModel>> Load()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("SavedExerciseData.json");
            using var reader = new StreamReader(stream);

            string json = await reader.ReadToEndAsync();

            var result = JsonSerializer.Deserialize<List<ExerciseModel>>(json);
            return result ?? new List<ExerciseModel>();
        }
    }
}
