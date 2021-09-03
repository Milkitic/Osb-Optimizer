using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;

namespace TextEditorTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_OnInitialized(object? sender, EventArgs e)
        {
            var text = File.ReadAllText(
                @"G:\GitHub\ReOsuStoryboardPlayerFork\ReOsuStoryboardPlayer.Core.UnitTest\TestData\Camellia vs Akira Complex - Reality Distortion (rrtyui).osb"
                //@"G:\GitHub\ReOsuStoryboardPlayerFork\ReOsuStoryboardPlayer.Core.UnitTest\TestData\IOSYS feat. 3L - Miracle-Hinacle (_lolipop).osb"
                );
            TextEditor.Text = text;
            ReloadSyntaxHighlighting();
        }

        private void ReloadSyntaxHighlighting()
        {
            try
            {
                using (XmlTextReader reader = new XmlTextReader(@"..\..\..\osbc.xshd"))
                {
                    var xshd = HighlightingLoader.LoadXshd(reader);
                    TextEditor.SyntaxHighlighting = HighlightingLoader.Load(xshd, HighlightingManager.Instance);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            ReloadSyntaxHighlighting();
        }
    }
}
