using OAuthTester.ViewModels.Dialogue;

namespace OAuthTester;

public interface IApplicationWindowManager
{
    bool? ShowDialog (ClientEditorWindowViewModel viewModel);
    bool? ShowDialog (AuthenticationServerEditorWindowViewModel viewModel);
    bool? ShowDialog (ClientTypeEditorWindowsViewModel viewModel);
    
}