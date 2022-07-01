using OauthTester.ViewModels;

namespace OAuthTester.ViewModels.Dialogue;

public class AuthenticationServerEditorWindowViewModel : WindowViewModel
{
    private string? _displayName;
    private string? _serviceUrl;

    public override string Title => "Edit authentication server";

    public string? DisplayName
    {
        get => _displayName;
        set
        {
            _displayName = value;
            OnPropertyChanged();
        }
    }

    public string? ServiceUrl
    {
        get => _serviceUrl;
        set
        {
            _serviceUrl = value;
            OnPropertyChanged();
        }
    }
}