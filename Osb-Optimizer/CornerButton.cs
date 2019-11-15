using Avalonia;
using Avalonia.Controls;

namespace OsbOptimizer
{
    public class CornerButton : Button
    {
        public static readonly StyledProperty<CornerRadius> CornerRadiusProperty =
            AvaloniaProperty.Register<CornerButton, CornerRadius>(nameof(CornerRadius));

        public CornerRadius CornerRadius
        {
            get => GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
    }
}
