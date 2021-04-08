using Milki.OsbOptimizer.ViewModels;
using System.Windows;

namespace Milki.OsbOptimizer.Windows
{
    /// <summary>
    /// DetailWindow.xaml 的交互逻辑
    /// </summary>
    public partial class DetailWindow : Window
    {
        private OptimizeViewModel ViewModel { get; }

        public DetailWindow(OptimizeViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = viewModel;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
