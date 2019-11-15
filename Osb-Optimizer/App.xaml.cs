using Avalonia;
using Avalonia.Markup.Xaml;

namespace OsbOptimizer
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
