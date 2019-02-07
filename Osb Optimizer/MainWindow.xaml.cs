using Milky.OsbOptimizer.ViewModels;
using System.Windows;
using Microsoft.Win32;

namespace Milky.OsbOptimizer
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        internal MainViewModel ViewModel { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel = (MainViewModel)DataContext;
        }

        private void BtnBrowse_Click(object sender, RoutedEventArgs e)
        {
            var ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                //ViewModel.Compressors.Add((ofd.FileName, null));
                ViewModel.HoldingPath = ofd.FileName;
            }
        }
    }
}
