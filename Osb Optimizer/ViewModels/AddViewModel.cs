using Microsoft.Win32;
using Milky.WpfApi;
using Milky.WpfApi.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Milky.OsbOptimizer.ViewModels
{
    public class AddViewModel : ViewModelBase
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
