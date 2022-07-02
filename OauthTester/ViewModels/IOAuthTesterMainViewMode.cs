using OAuthTester.ViewModels.Dialogue;

namespace OauthTester.ViewModels;

public interface IOAuthTesterMainViewMode : IWindowViewModel
{
    bool HasSelection { get; }
}