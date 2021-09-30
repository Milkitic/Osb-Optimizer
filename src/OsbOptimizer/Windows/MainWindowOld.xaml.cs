using System.Windows;
using Milki.OsbOptimizer.ViewModels;

namespace Milki.OsbOptimizer.Windows
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindowOld : Window
    {
        internal MainViewModel ViewModel { get; private set; }
        public MainWindowOld()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel = (MainViewModel)DataContext;
        }
    }
}
