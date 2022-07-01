namespace OAuthTester.ViewModels.ClientTypes;

public class WebOnlyAuthenticationTypeViewModel : AuthenticationTypeViewModel
{
    public override bool ShowClientId => false;
    public override bool ShowSecret => false;
    public override string DisplayName => "Public web";
    public override bool ShowPassword => false;
}