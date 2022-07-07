using OAuthTester.ViewModels;

namespace OauthTester.ViewModels;

public interface IOAuthTesterMainViewMode : IWindowViewModel
{
    bool HasSelection { get; }
}