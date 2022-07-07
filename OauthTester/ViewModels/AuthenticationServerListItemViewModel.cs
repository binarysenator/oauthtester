using System;
using OAuthTester.Engine;
using OauthTester.ViewModels;

namespace OAuthTester.ViewModels;

public class AuthenticationServerListItemViewModel : ViewModel
{
    private Guid _id;
    private string? _authenticationUrl;
    private string? _displayName;
    public AuthenticationServerListItemViewModel() { }

    public static AuthenticationServerListItemViewModel From (AuthenticationServer server)
    {
        if (server == null) throw new ArgumentNullException(nameof(server));
        return new AuthenticationServerListItemViewModel()
        {
            Id = server.Id,
            AuthenticationUrl = server.AuthenticationUrl,
            DisplayName = server.Name,
        };
    }

    public Guid Id
    {
        get => _id;
        set 
        { 
            _id = value; 
            OnPropertyChanged();
        }
    }

    public string? AuthenticationUrl
    {
        get => _authenticationUrl;
        set
        {
            _authenticationUrl = value; 
            OnPropertyChanged();
        }
    }

    public string? DisplayName
    {
        get => _displayName;
        set
        {
            _displayName = value; 
            OnPropertyChanged();
        }
    }
}