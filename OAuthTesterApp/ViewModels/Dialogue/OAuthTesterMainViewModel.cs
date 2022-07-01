using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Windows.Input;
using OAuthTester.Engine;
using OauthTester.ViewModels;
using OAuthTesterApp.Dialogues;
using Redbridge;

namespace OAuthTesterApp.ViewModels.Dialogue;

public class OAuthTesterMainViewModel : ViewModel, IOAuthTesterMainViewMode
{
    private readonly IApplicationWindowManager _applicationWindowManager;
    private readonly IHttpClientFactory _clientFactory;
    private readonly IConfigurationLoader _configurationLoader;
    private OAuthClientViewModel? _selectedClient = null;
    private readonly DelegateCommand _startCommand;
    private readonly DelegateCommand _stopCommand;
    private readonly DelegateCommand _addCommand;
    private readonly DelegateCommand _deleteCommand;

    public OAuthTesterMainViewModel(IApplicationWindowManager applicationWindowManager, IHttpClientFactory clientFactory, IConfigurationLoader configurationLoader)
    {
        _applicationWindowManager = applicationWindowManager ?? throw new ArgumentNullException(nameof(applicationWindowManager));
        _clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));
        _configurationLoader = configurationLoader ?? throw new ArgumentNullException(nameof(configurationLoader));

        _addCommand = new DelegateCommand((obj) =>
        {
            var window = _applicationWindowManager.Create<ClientEditorWindow>();
            window.ClientConfiguration = new ClientConfiguration();

            if (_applicationWindowManager.ShowDialogue(window) ?? false )
            {
                var configuration = window.ClientConfiguration;
                AddOrUpdate(configuration);
            }
        });
        _deleteCommand = new DelegateCommand((obj) => { }, (obj) => SelectedClient != null);
        _startCommand = new DelegateCommand((obj) => { },(obj) => SelectedClient?.IsStopped ?? false);
        _stopCommand = new DelegateCommand((obj) => { }, (obj) => SelectedClient?.IsRunning ?? false);

        OnLoad();
    }

    private void AddOrUpdate(ClientConfiguration configuration)
    {
        if (configuration == null) throw new ArgumentNullException(nameof(configuration));
        var toUpdate = _configurationLoader.Configuration.Clients.FirstOrDefault(cl => cl.Id == configuration.Id);

        if (toUpdate == null)
        {
            // Add 

        }
    }

    private OAuthClientViewModel Create(ClientConfiguration configuration)
    {
        return new OAuthClientViewModel(_clientFactory, _configurationLoader);
    }

    private void OnLoad()
    {
        _configurationLoader.Load();
        var configuration = _configurationLoader.Configuration;
        configuration.Clients.ForEach(c => Clients.Add(Create(c)));
    }

    public OAuthClientViewModel? SelectedClient
    {
        get => _selectedClient;
        set
        {
            _selectedClient = value;
            OnPropertyChanged();
            _addCommand.OnCanExecuteChanged();
            _deleteCommand.OnCanExecuteChanged();
            _startCommand.OnCanExecuteChanged();
            _stopCommand.OnCanExecuteChanged();
            OnPropertyChanged(nameof(HasSelection));
        }
    }

    public ICommand StartCommand => _startCommand;
    public ICommand StopCommand => _stopCommand;
    public ICommand AddCommand => _addCommand;
    public ICommand DeleteCommand => _deleteCommand;


    public ObservableCollection<OAuthClientViewModel> Clients { get; } = new ObservableCollection<OAuthClientViewModel>();
    public bool HasSelection => SelectedClient != null;
}