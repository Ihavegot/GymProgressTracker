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
            if (!File.Exists(FilePath))
                return new List<Exercise>();

            var rawData = await File.ReadAllTextAsync(FilePath);
            if (string.IsNullOrEmpty(rawData))
                return new List<Exercise>();

            return JsonSerializer.Deserialize<List<Exercise>>(rawData) ?? new List<Exercise>();
        }

        public async Task Write(Exercise exercise)
        {
            var exerciseList = await Read();
            exerciseList.Add(exercise);
            await Write(exerciseList);
        }

        public async Task Write(List<Exercise> exerciseList)
        {
            var json = JsonSerializer.Serialize(exerciseList);
            await File.WriteAllTextAsync(FilePath, json);
        }

        public async Task Update(Exercise exercise)
        {
            var data = await Read();
            var index = data.FindIndex(x => x.Id == exercise.Id);
            if (index != -1)
            {
                data[index] = exercise;
                await Write(data);
            }
        }

        public async Task Delete(string id)
        {
            var data = await Read();
            data.RemoveAll(x => x.Id == id);
            await Write(data);
        }
    }
}
