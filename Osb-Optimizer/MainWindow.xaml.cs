using Avalonia;
using Avalonia.Controls;
using Avalonia.Diagnostics.ViewModels;
using Avalonia.Markup.Xaml;

namespace OsbOptimizer
{
    public class MainWindowVm : ViewModelBase
    {
        public void AddCommand()
        {
            var newWin = new NewTaskWindow();
            newWin.ShowDialog(App.Current.MainWindow);
        }
    }

    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
