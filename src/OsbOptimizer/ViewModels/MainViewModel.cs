using Milki.OsbOptimizer.Windows;
using Milki.Utils.WPF.Interaction;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Milki.OsbOptimizer.ViewModels
{
    public class MainViewModel : VmBase
    {
        public ObservableCollection<OptimizeViewModel> Compressors { get; set; } =
            new ObservableCollection<OptimizeViewModel>()
            {
                //new OptimizeViewModel("E:\\Test\\why.bak"),
                //new OptimizeViewModel("E:\\Test\\why.bak"),
                //new OptimizeViewModel("E:\\Test\\why.bak")
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
