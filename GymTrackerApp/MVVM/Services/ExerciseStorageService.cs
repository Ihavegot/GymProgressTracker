using GymTrackerApp.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace GymTrackerApp.MVVM.Services
{
    class ExerciseStorageService
    {
        public string FilePath = FileSystem.AppDataDirectory + "/SavedExerciseData.json";
        public async Task<Exercise> Read()
        {
            if (File.Exists(FilePath) == false)
            {
                return new Exercise();
            }

            var rawData = File.ReadAllText(FilePath);
            var deserializedExercise = JsonSerializer.Deserialize<Exercise>(rawData);

            if (deserializedExercise != null)
            {
                return deserializedExercise;
            }

            return new Exercise();
        }

        public async Task Write(Exercise exercise)
        {
            var json = JsonSerializer.Serialize(exercise);
            File.WriteAllText(FilePath, json);
        }
    }
}
