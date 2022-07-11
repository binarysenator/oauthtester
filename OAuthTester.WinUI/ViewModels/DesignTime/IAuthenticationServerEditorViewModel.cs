using System.Windows.Input;
using Redbridge.WinUI;

namespace OAuthTester.WinUI.ViewModels.DesignTime;

public interface IAuthenticationServerEditorViewModel : IWindowViewModel
{
    ICommand OKCommand { get; }
}