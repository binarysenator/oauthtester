using OAuthTester.ViewModels.Dialogue;
using OAuthTesterApp.ViewModels;

namespace OauthTester.ViewModels;

public abstract class WindowViewModel : ViewModel, IWindowViewModel
{
    public abstract string Title { get; }
}