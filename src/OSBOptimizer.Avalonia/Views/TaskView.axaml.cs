using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaEdit;
using OSBOptimizer.Avalonia.ViewModels;

namespace OSBOptimizer.Avalonia.Views
{
    public partial class TaskView : UserControl
    {
        private TaskViewModel? _viewModel;
        private TextEditor _textEditor1;
        private TextEditor _textEditor2;

        public TaskView()
        {
            InitializeComponent();
            DataContextChanged += TaskView_DataContextChanged;
        }

        private void TaskView_DataContextChanged(object? sender, System.EventArgs e)
        {
            _viewModel = (TaskViewModel?)this.DataContext;
            if (_viewModel != null)
            {
                _textEditor1.Text = _viewModel.Text1;
                _textEditor2.Text = _viewModel.Text2;
            }
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        protected override void OnInitialized()
        {
            _textEditor1 = this.FindControl<TextEditor>("TextEditor1");
            _textEditor2 = this.FindControl<TextEditor>("TextEditor2");

        }
    }
}
