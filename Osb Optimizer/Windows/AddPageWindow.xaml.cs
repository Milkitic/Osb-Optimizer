using Milki.OsbOptimizer.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;

namespace Milki.OsbOptimizer.Windows
{
    /// <summary>
    /// AddPageWindow.xaml 的交互逻辑
    /// </summary>
    public partial class AddPageWindow : Window
    {
        private readonly ObservableCollection<OptimizeViewModel> _collection;

        public AddViewModel ViewModel { get; set; }

        public AddPageWindow(ObservableCollection<OptimizeViewModel> collection)
        {
            _collection = collection;
            InitializeComponent();
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            _collection.Add(new OptimizeViewModel(ViewModel.HoldingPath));
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel = (AddViewModel)DataContext;
        }
    }
}
