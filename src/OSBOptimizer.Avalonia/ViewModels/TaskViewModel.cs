using System;
using System.Diagnostics;
using System.IO;
using ReactiveUI;

namespace OSBOptimizer.Avalonia.ViewModels
{
    [DebuggerDisplay("Name = {Name}")]
    public class TaskViewModel : ViewModelBase
    {
        private bool _isRunning;
        private bool _isFinished;
        private bool _isPaused;
        private float _progress;

        public TaskViewModel()
        {
        }

        public TaskViewModel(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("Path can not be empty.");

            //if (!File.Exists(filePath))
            //    throw new FileNotFoundException($"Can not find file: \"{filePath}\"");

            FilePath = filePath;
            Name = Path.GetFileNameWithoutExtension(filePath);
        }

        public Guid Guid { get; internal set; } = Guid.NewGuid();
        public string FilePath { get; } = null!;
        public string Name { get; } = null!;

        public bool IsRunning
        {
            get => _isRunning;
            set => this.RaiseAndSetIfChanged(ref _isRunning, value);
        }

        public bool IsFinished
        {
            get => _isFinished;
            set => this.RaiseAndSetIfChanged(ref _isFinished, value);
        }

        public bool IsPaused
        {
            get => _isPaused;
            set => this.RaiseAndSetIfChanged(ref _isPaused, value);
        }

        public float Progress
        {
            get => _progress;
            set => this.RaiseAndSetIfChanged(ref _progress, value);
        }

        public string Text1 { get; set; } = @"Sprite,Background,Centre,""SB\pixel.png"",320,240
 S,0,57,,0.6
 S,0,10724,11224,0.6,0
 F,0,8607,,0,1
 C,0,57,,255,255,0
 MX,0,57,10724,320
 MX,1,10724,11224,320,347.987
 MY,1,8877,9077,412,392
 MY,1,9627,9827,392,372
 MY,1,10724,11224,372,413.434
 P,0,57,10724,A
";

        public string Text2 { get; set; } = @"Sprite,Background,Centre,""SB\pixel.png"",320,240
 S,0,57,,0.6
 S,0,10724,11224,0.6,0
 F,0,8607,,0,1
 C,0,57,,255,255,0
 MX,1,10724,11224,320,347.987
 MY,1,8877,9077,412,392
 MY,1,9627,9827,392,372
 MY,1,10724,11224,372,413.434
 P,0,57,10724,A
";
    }
}