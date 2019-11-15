using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Diagnostics.ViewModels;
using Avalonia.Markup.Xaml;

namespace OsbOptimizer
{
    public class NewTaskWindowVm : ViewModelBase
    {
        private string _holdingPath;

        public string HoldingPath
        {
            get => _holdingPath;
            set
            {
                _holdingPath = value;
                RaisePropertyChanged();
            }
        }

        public async void BrowseCommand()
        {
            var ofd = new OpenFileDialog
            {
                Filters = new List<FileDialogFilter>
                {
                    new FileDialogFilter
                    {
                        Extensions = new List<string>
                        {
                            "*"
                        },
                        Name = "All files"
                    }
                }
            };

            var selected = await ofd.ShowAsync(App.Current.MainWindow);

            var fileName = selected.FirstOrDefault();
            if (fileName != null)
            {
                HoldingPath = fileName;
            }
        }

        public void OKCommand()
        {

        }
    }

    public class NewTaskWindow : Window
    {
        public NewTaskWindow()
        {
            this.InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
