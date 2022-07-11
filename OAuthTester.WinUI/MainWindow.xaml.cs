using Microsoft.UI.Xaml;
using OAuthTester.ViewModels.Dialogue;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace OAuthTester.WinUI
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow(OAuthTesterMainViewModel viewModel)
        {
            this.InitializeComponent();
            this.MainGrid.DataContext = viewModel;
        }
    }
}
