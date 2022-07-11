using System.Windows.Input;
using Redbridge.WinUI.Commands;

namespace OAuthTester.WinUI.ViewModels.DesignTime;

public class DesignTimeAuthenticationServerEditorViewModel : IAuthenticationServerEditorViewModel
{
    public string Title => "Authentication server editor";
    public bool? DialogResult => null;
    public ICommand OKCommand => new DelegateCommand((obj) => { });
}