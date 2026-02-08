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
        public async Task<List<Exercise>> Read()
        {
            if (File.Exists(FilePath) == false)
            {
                return new List<Exercise>();
            }

            var rawData = File.ReadAllText(FilePath);
            if (rawData.Length == 0)
            {
                return new List<Exercise>();
            }
            var deserializedExercise = JsonSerializer.Deserialize<List<Exercise>>(rawData);

            if (deserializedExercise != null)
            {
                return deserializedExercise;
            }

            return new List<Exercise>();
        }

        public async Task Write(Exercise exercise)
        {
            var exerciseList = new List<Exercise>();
            foreach (var item in await Read())
            {
                exerciseList.Add(item);
            }
            exerciseList.Add(exercise);

            var json = JsonSerializer.Serialize(exerciseList);
            File.WriteAllText(FilePath, json);
        }

        public async Task Write(List<Exercise> exerciseList)
        {
            var json = JsonSerializer.Serialize(exerciseList);
            File.WriteAllText(FilePath, json);
        }

        public async Task Delete(string id)
        {
            var data = await Read();
            data.RemoveAll(x => x.Id == id);
            await Write(data);
        }
    }
}
