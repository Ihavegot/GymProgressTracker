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
    public class ExerciseTypeViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ExerciseType> ExerciseTypes { get; }

        private ExerciseType _selectedExercise;
        public ExerciseType SelectedExercise
        {
            get => _selectedExercise;
            set
            {
                if (_selectedExercise != value)
                {
                    _selectedExercise = value;
                    OnPropertyChanged();
                }
            }
        }

        public ExerciseTypeViewModel()
        {
            ExerciseTypes = new ObservableCollection<ExerciseType>(Enum.GetValues(typeof(ExerciseType)).Cast<ExerciseType>());
            SelectedExercise = ExerciseType.FBW;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
