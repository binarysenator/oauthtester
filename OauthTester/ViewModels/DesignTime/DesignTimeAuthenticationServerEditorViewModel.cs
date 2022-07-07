using System.Windows.Input;
using OAuthTester.ViewModels.Commands;

namespace OAuthTester.ViewModels.DesignTime;

public class DesignTimeAuthenticationServerEditorViewModel : IAuthenticationServerEditorViewModel
{
    public string Title => "Authentication server editor";
    public bool? DialogResult => null;
    public ICommand OKCommand => new DelegateCommand((obj) => { });
}