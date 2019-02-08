using Microsoft.Win32;
using Milky.WpfApi;
using Milky.WpfApi.Commands;
using OSharp.Storyboard;
using OSharp.Storyboard.Management;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Input;
using ErrorEventArgs = OSharp.Storyboard.ErrorEventArgs;

namespace Milky.OsbOptimizer.ViewModels
{
    public class OptimizeViewModel : ViewModelBase, IDisposable
    {
        private float _progress;

        private bool _paused;
        private bool _isRunning;
        private bool _isFinished;

        private StringBuilder _holdingText = new StringBuilder();

        private ElementGroup _group;
        private ElementCompressor _compressor;
        private int tmp;

        public string FilePath { get; }
        public string Name { get; }
        public Guid Guid { get; set; } = Guid.NewGuid();

        public OptimizeViewModel(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("Path can not be empty.");
            }

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Can not find file: \"{filePath}\"");
            }

            FilePath = filePath;
            Name = Path.GetFileNameWithoutExtension(filePath);
        }

        public bool IsRunning
        {
            get => _isRunning;
            private set
            {
                _isRunning = value;
                OnPropertyChanged();
            }
        }
        public bool IsFinished
        {
            get => _isFinished;
            private set
            {
                _isFinished = value;
                OnPropertyChanged();
            }
        }

        public bool Paused
        {
            get => _paused;
            private set
            {
                _paused = value;
                OnPropertyChanged();
            }
        }

        public float Progress
        {
            get => _progress;
            private set
            {
                _progress = value;
                if (tmp != (int)(_progress * 150))
                {
                    OnPropertyChanged();
                    tmp = (int)(_progress * 150);
                }
            }
        }

        public StringBuilder HoldingText
        {
            get => _holdingText;
            set
            {
                _holdingText = value;
                OnPropertyChanged();
            }
        }

        public ErrorEventArgs HoldingArg { get; set; }

        public ICommand StartCommand
        {
            get
            {
                return new DelegateCommand(async arg =>
                {
                    IsFinished = false;
                    IsRunning = true;
                    //Compressors.Add(new OptimizeInstance(holdingPath));
                    _group = await ElementGroup.ParseFromFileAsync(FilePath);
                    _compressor = new ElementCompressor(_group)
                    {
                        ThreadCount = 2
                    };
                    var compressor = _compressor;
                    compressor.ErrorOccured += (object sender, ErrorEventArgs e) =>
                    {
                        //HoldingArg = e;
                        //HoldingText.AppendLine(e.Message);
                        //OnPropertyChanged(nameof(HoldingText));
                        //Paused = true;
                        //while (Paused)
                        //{
                        //    Thread.Sleep(1);
                        //}
                    };
                    compressor.ProgressChanged += (object sender, ProgressEventArgs e) =>
                    {
                        //Thread.Sleep(1);
                        Progress = e.Progress / (float)e.TotalCount;
                    };
                    await _compressor.CompressAsync();
                    await _group.SaveOsbFileAsync(
                        Path.Combine(Path.GetDirectoryName(FilePath),
                            Path.GetFileNameWithoutExtension(FilePath) + ".osb"
                        )
                    );
                    IsRunning = false;
                    IsFinished = true;
                    compressor.ErrorOccured = null;
                    compressor.ProgressChanged = null;
                    Dispose();
                });
            }
        }

        public ICommand FixCommand
        {
            get
            {
                return new DelegateCommand(arg =>
                {
                    HoldingArg.Continue = true;
                    Paused = false;
                });
            }
        }

        public ICommand KeepCommand
        {
            get
            {
                return new DelegateCommand(arg =>
                {
                    HoldingArg.Continue = false;
                    Paused = false;
                });
            }
        }

        public ICommand RemoveCommand
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    var collection = (ObservableCollection<OptimizeViewModel>)obj;
                    this.Dispose();
                    collection.Remove(this);
                });

            }
        }

        public void Dispose()
        {
            _group?.Dispose();
            _compressor?.Dispose();
            HoldingText?.Clear();
            HoldingText = null;
            HoldingArg = null;
        }
    }
}