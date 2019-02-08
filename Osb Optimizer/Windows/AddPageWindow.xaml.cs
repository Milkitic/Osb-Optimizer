using Milky.OsbOptimizer.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Milky.OsbOptimizer.Windows
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
