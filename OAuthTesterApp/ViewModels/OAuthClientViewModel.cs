using System.Net.Http;
using System.Windows.Input;
using OAuthTester.Engine;
using OauthTester.ViewModels;
using OAuthTesterApp.ViewModels.Commands;

namespace OAuthTesterApp.ViewModels;

public class OAuthClientViewModel : ViewModel, IOAuthClientViewModel
{
    private string? _clientId;
    private string? _clientSecret;
    private string? _username;
    private string? _displayName;
    private string? _password;
    private readonly OAuth2Client _client;
    private ICommand _toggleStateCommand;
    
    public OAuthClientViewModel(IHttpClientFactory clientFactory, ClientConfiguration configuration, IConfigurationManager configurationLoader)
    {
        _client = new OAuth2Client(clientFactory, configuration, configurationLoader);
        OnSetupCommands();
    }

    public OAuthClientViewModel(IHttpClientFactory clientFactory, IConfigurationManager configurationLoader)
    {
        _client = new OAuth2Client(clientFactory, configurationLoader);
        OnSetupCommands();
    }

    private void OnSetupCommands()
    {
        _toggleStateCommand = new DelegateCommand(async (obj) =>
        {
            if (_client.CurrentStatus == ClientStatus.Running)
            {
                _client.Stop();
            }

            if (_client.CurrentStatus == ClientStatus.Stopped)
            {
                await _client.Start();
            }
        });
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
    public bool IsStopped => _client.CurrentStatus == ClientStatus.Stopped || _client.CurrentStatus == ClientStatus.Error;
}