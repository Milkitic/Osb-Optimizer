using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using Avalonia.Controls.Selection;
using ReactiveUI;

namespace OSBOptimizer.Avalonia.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            Selection = new SelectionModel<TaskViewModel>();
            Selection.SelectionChanged += SelectionChanged;
        }

        private TaskViewModel? _selectedTask;
        public ObservableCollection<TaskViewModel> Tasks { get; } = new()
        {
            new TaskViewModel(@"C:\Users\milkitic\Desktop\OsbOptimizer\asdf.exe"),
            new TaskViewModel(@"C:\Users\milkitic\Desktop\OsbOptimizer\asdf.exe"),
            new TaskViewModel(@"C:\Users\milkitic\Desktop\OsbOptimizer\asdf.exe"),
        };

        public TaskViewModel? SelectedTask
        {
            get => _selectedTask;
            set => this.RaiseAndSetIfChanged(ref _selectedTask, value);
        }

        public SelectionModel<TaskViewModel> Selection { get; }

        public string Greeting => "Welcome to Avalonia!";

        void AddTask()
        {
            Tasks.Add(new TaskViewModel(Path.GetRandomFileName() + "." + Path.GetRandomFileName()));
        }

        private void SelectionChanged(object? sender, SelectionModelSelectionChangedEventArgs<TaskViewModel> e)
        {
            var selectedItem = e.SelectedItems.Count == 1 ? Tasks[e.SelectedIndexes[0]] : null;
            SelectedTask = selectedItem;
        }
    }
}
