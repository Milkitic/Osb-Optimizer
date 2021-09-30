using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace OSBOptimizer.Avalonia.Views
{
    public partial class TaskListView : UserControl
    {
        public TaskListView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
