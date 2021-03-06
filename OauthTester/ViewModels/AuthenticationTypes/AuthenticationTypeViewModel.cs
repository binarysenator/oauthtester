using OauthTester.ViewModels;

namespace OAuthTester.ViewModels.AuthenticationTypes;

public abstract class AuthenticationTypeViewModel : ViewModel
{
    public virtual bool ShowPassword => true;
    public virtual bool ShowClientId => true;
    public virtual bool ShowSecret => true;
    public abstract string DisplayName { get; }
}