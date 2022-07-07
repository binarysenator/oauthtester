using System.Windows.Input;
using OAuthTester.Engine;
using OAuthTester.ViewModels.Commands;

namespace OauthTester.ViewModels;

public class OAuthClientViewModel : ViewModel, IOAuthClientViewModel
{
    private string? _clientId;
    private string? _clientSecret;
    private string? _username;
    private string? _displayName;
    private string? _password;
    private readonly OAuth2Client _client;
    private ICommand _toggleStateCommand;
    
    public OAuthClientViewModel(ClientConfiguration configuration, IConfigurationManager configurationLoader, IAuthenticationTypeFactory authenticationTypeFactory)
    {
        _client = new OAuth2Client( configuration, configurationLoader, authenticationTypeFactory);
        _toggleStateCommand = new DelegateCommand((obj) =>
        {
            if (_client.CurrentStatus == ClientStatus.Running)
            {
                _client.Stop();
            }

            if (_client.CurrentStatus == ClientStatus.Stopped)
            { 
                _client.Start();
            }
        });
    }

    public void Start()
    {
        _client.Start();
    }

    public void Stop()
    {
        _client.Stop();
    }

    public string? ClientId
    {
        get => _clientId;
        set
        {
            _clientId = value;
            OnPropertyChanged();
        }
    }

    public string? ClientSecret
    {
        get => _clientSecret;
        set
        {
            _clientSecret = value;
            OnPropertyChanged();
        }
    }

    public string? Username
    {
        get => _username;
        set
        {
            _username = value;
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

    public ClientStatus Status => _client.CurrentStatus;

    public ICommand ToggleStateCommand => _toggleStateCommand;

    public string? Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChanged();
        }
    }

    public bool IsRunning => _client.CurrentStatus == ClientStatus.Running;
    public bool IsStopped => _client.CurrentStatus is ClientStatus.Stopped or ClientStatus.Error;
}