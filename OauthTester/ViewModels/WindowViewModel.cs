using OAuthTester.ViewModels.Dialogue;

namespace OauthTester.ViewModels;

public abstract class WindowViewModel : ViewModel, IWindowViewModel
{
    public abstract string Title { get; }
}