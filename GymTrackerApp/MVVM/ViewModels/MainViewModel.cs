using GymTrackerApp.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GymTrackerApp.MVVM.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private List<Exercise> _allExercises;
        private ObservableCollection<Exercise>? _exercises;
        
        public ObservableCollection<Exercise> Exercise
        {
            get => _exercises;
            set
            {
                _exercises = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ExerciseType> ExerciseTypes { get; }

        public MainViewModel()
        {
            _allExercises = new List<Exercise>();
            Exercise = new ObservableCollection<Exercise>();
            ExerciseTypes = new ObservableCollection<ExerciseType>(
                Enum.GetValues(typeof(ExerciseType)).Cast<ExerciseType>()
            );
        }

        public void FilterByType(ExerciseType type)
        {
            Exercise.Clear();
            var filtered = _allExercises.Where(e => e.Type == type);
            foreach (var item in filtered)
            {
                Exercise.Add(item);
            }
        }

        public void ClearFilter()
        {
            Exercise.Clear();
            foreach (var item in _allExercises)
            {
                Exercise.Add(item);
            }
        }

        public void LoadExercises(List<Exercise> exercises)
        {
            _allExercises = exercises;
            Exercise.Clear();
            foreach (var exercise in exercises)
            {
                Exercise.Add(exercise);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
