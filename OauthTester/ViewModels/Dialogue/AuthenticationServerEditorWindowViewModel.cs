using System;
using OAuthTester.Engine;
using OauthTester.ViewModels;

namespace OAuthTester.ViewModels.Dialogue;

public class AuthenticationServerEditorWindowViewModel : WindowViewModel
{
    private Guid _id;
    private string? _displayName;
    private string? _serviceUrl;
    public override string Title => "Edit authentication server";

    public AuthenticationServerEditorWindowViewModel() { }

    public static AuthenticationServerEditorWindowViewModel From (AuthenticationServer server)
    {
        if (server == null) throw new ArgumentNullException(nameof(server));
        return new AuthenticationServerEditorWindowViewModel()
        {
            Id = server.Id,
            DisplayName = server.DisplayName,
            AuthenticationUrl = server.AuthenticationUrl,
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

    public string? DisplayName
    {
        get => _displayName;
        set
        {
            _displayName = value;
            OnPropertyChanged();
        }
    }

    public string? AuthenticationUrl
    {
        get => _serviceUrl;
        set
        {
            _serviceUrl = value;
            OnPropertyChanged();
        }
    }
}