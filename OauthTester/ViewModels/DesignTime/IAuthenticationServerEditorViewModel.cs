using System.Windows.Input;

namespace OAuthTester.ViewModels.DesignTime;

public interface IAuthenticationServerEditorViewModel : IWindowViewModel
{
    ICommand OKCommand { get; }
}