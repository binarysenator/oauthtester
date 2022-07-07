using System;
using System.Windows.Input;
using OAuthTester.Engine;
using OauthTester.ViewModels;
using OAuthTester.ViewModels.Commands;
using OAuthTester.ViewModels.DesignTime;

namespace OAuthTester.ViewModels.Dialogue;

public class AuthenticationServerEditorWindowViewModel : WindowViewModel, IAuthenticationServerEditorViewModel
{
    private Guid _id;
    private string? _displayName;
    private string? _serviceUrl;
    public override string Title => "Edit authentication server";
    private readonly DelegateCommand _okCommand;

    public AuthenticationServerEditorWindowViewModel()
    {
        _okCommand = new DelegateCommand((obj) =>
        {
            DialogResult = true;
        });
    }

    public static AuthenticationServerEditorWindowViewModel From (AuthenticationServer server)
    {
        if (server == null) throw new ArgumentNullException(nameof(server));
        return new AuthenticationServerEditorWindowViewModel()
        {
            Id = server.Id,
            DisplayName = server.Name,
            AuthenticationUrl = server.AuthenticationUrl,
        };
    }

    public ICommand OKCommand => _okCommand;

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