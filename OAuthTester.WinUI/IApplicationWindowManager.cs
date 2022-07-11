using Microsoft.UI.Xaml.Controls;
using OAuthTester.ViewModels.Dialogue;
using System.Threading.Tasks;

namespace OAuthTester;

public interface IApplicationWindowManager
{
    Task<ContentDialogResult> ShowDialog (ClientEditorWindowViewModel viewModel);
    bool? ShowDialog (AuthenticationServerEditorWindowViewModel viewModel);
    bool? ShowDialog (ClientTypeEditorWindowsViewModel viewModel);
    
}