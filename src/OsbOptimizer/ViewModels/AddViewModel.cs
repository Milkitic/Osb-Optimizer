using System.Windows.Input;
using Microsoft.Win32;
using Milki.Utils.WPF.Interaction;

namespace Milki.OsbOptimizer.ViewModels
{
    public class AddViewModel : VmBase
    {
        private string _holdingPath;

        public string HoldingPath
        {
            get => _holdingPath;
            set
            {
                _holdingPath = value;
                OnPropertyChanged();
            }
        }

        public ICommand BrowseCommand
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    var ofd = new OpenFileDialog();
                    if (ofd.ShowDialog() == true)
                    {
                        HoldingPath = ofd.FileName;
                    }
                });
            }
        }
    }
}
