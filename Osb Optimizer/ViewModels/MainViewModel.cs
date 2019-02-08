using System;
using Milky.WpfApi;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using Milky.OsbOptimizer.Windows;
using Milky.WpfApi.Commands;

namespace Milky.OsbOptimizer.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<OptimizeViewModel> Compressors { get; set; } =
            new ObservableCollection<OptimizeViewModel>()
            {
                new OptimizeViewModel("E:\\Test\\why.bak"),
                new OptimizeViewModel("E:\\Test\\why.bak"),
                new OptimizeViewModel("E:\\Test\\why.bak")
            };

        public ICommand AddCommand
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    var window = new AddPageWindow(Compressors);
                    try
                    {
                        window.ShowDialog();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                });

            }
        }
    }
}
