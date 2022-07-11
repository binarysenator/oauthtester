using Redbridge.WinUI;

namespace OAuthTester.WinUI.ViewModels;

public interface IOAuthTesterMainViewMode : IWindowViewModel
{
    bool HasSelection { get; }
}