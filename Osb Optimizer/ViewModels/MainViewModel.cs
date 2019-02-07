using Milky.WpfApi;
using Milky.WpfApi.Commands;
using OSharp.Storyboard;
using OSharp.Storyboard.Management;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Milky.OsbOptimizer.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        private string _holdingPath;

        public ObservableCollection<OptimizeInstance> Compressors { get; set; } =
            new ObservableCollection<OptimizeInstance>();

        public bool IsRunning => Compressors.Count != 0 && Compressors[0].IsRunning;
        public float Progress => Compressors.Count == 0 ? 0 : Compressors[0].Progress;

        public string HoldingPath
        {
            get => _holdingPath;
            set
            {
                _holdingPath = value;
                OnPropertyChanged();
            }
        }

        public ICommand StartCommand
        {
            get
            {
                return new DelegateCommand(async arg =>
                {
                    Compressors.Clear();
                    Compressors.Add(new OptimizeInstance(HoldingPath));
                    Compressors[0].Group = await ElementGroup.ParseFromFileAsync(HoldingPath);
                    Compressors[0].Compressor = new ElementCompressor(Compressors[0].Group)
                    {
                        ThreadCount = 4
                    };
                    var compressor = Compressors[0].Compressor;
                    compressor.OnErrorOccured += (object sender, ErrorEventArgs e) =>
                    {
                        Compressors[0].HoldingArg = e;
                        Compressors[0].HoldingText = e.Message;
                        while (Compressors[0].HoldingText != null)
                        {
                            Thread.Sleep(1);
                        }
                    };
                    compressor.OnProgressChanged += (object sender, ProgressEventArgs e) =>
                    {
                        Compressors[0].Progress = e.Progress / (float)e.TotalCount;
                    };
                    Compressors[0].IsRunning = true;
                    await Compressors[0].Compressor.CompressAsync();
                    Compressors[0].IsRunning = false;
                    compressor.OnErrorOccured = null;
                    compressor.OnProgressChanged = null;
                });
            }
        }

        public ICommand FixCommand
        {
            get
            {
                return new DelegateCommand(arg =>
                {
                    Compressors[0].HoldingArg.TryToContinue = true;
                    Compressors[0].HoldingText = null;
                });
            }
        }

        public ICommand KeepCommand
        {
            get
            {
                return new DelegateCommand(arg =>
                {
                    Compressors[0].HoldingArg.TryToContinue = false;
                    Compressors[0].HoldingText = null;
                });
            }
        }

        public class OptimizeInstance : ViewModelBase
        {
            private float _progress;
            private string _holdingText;

            public OptimizeInstance(string path)
            {
                Path = path;
            }

            public bool IsRunning { get; set; }

            public float Progress
            {
                get => _progress;
                set
                {
                    _progress = value;
                    OnPropertyChanged();
                }
            }

            public string Path { get; set; }

            public ElementGroup Group { get; set; }

            public ElementCompressor Compressor { get; set; }

            public string HoldingText
            {
                get => _holdingText;
                set
                {
                    _holdingText = value;
                    OnPropertyChanged();
                }
            }

            public ErrorEventArgs HoldingArg { get; set; }
        }
    }
}
