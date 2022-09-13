using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using OSBOptimizer.Avalonia.ViewModels;

namespace OSBOptimizer.Avalonia.Views
{
    public partial class MainWindow : Window
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

        private void InputElement_OnDoubleTapped(object? sender, RoutedEventArgs e)
        {
            var viewModel = (MainWindowViewModel)DataContext;
            var source = e.Source!;
            while (source is not ListBox)
            {
                if (source is ListBoxItem { Tag: "PART_ListBoxItem" } lbi)
                {
                    var indexes = viewModel.Selection.SelectedIndexes;
                    var selectedItem = indexes.Count == 1 ? viewModel.Tasks[indexes[0]] : null;
                    viewModel.SelectedTask = selectedItem;
                    return;
                }

                source = source.InteractiveParent;
            }
        }
    }
}
