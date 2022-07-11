using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Disposables;
using System.Windows.Input;
using OAuthTester.Engine;
using Redbridge.WinUI;
using OAuthTester.WinUI.ViewModels;
using Redbridge.WinUI.Commands;

namespace OAuthTester.ViewModels.Dialogue;

public class OAuthTesterMainViewModel : WindowViewModel, IOAuthTesterMainViewMode
{
    private readonly IConfigurationManager _configurationLoader;
    private readonly IAuthenticationTypeFactory _authenticationTypeFactory;
    private OAuthClientViewModel? _selectedClient;
    private readonly DelegateCommand _startCommand;
    private readonly DelegateCommand _stopCommand;
    private readonly DelegateCommand _addCommand;
    private readonly DelegateCommand _deleteCommand;
    private readonly CompositeDisposable _compositeDisposable = new();

    public OAuthTesterMainViewModel(IApplicationWindowManager applicationWindowManager, IConfigurationManager configurationLoader, IAuthenticationTypeFactory authenticationTypeFactory)
    {
        if (authenticationTypeFactory == null) throw new ArgumentNullException(nameof(authenticationTypeFactory));
        var applicationWindowManager1 = applicationWindowManager ?? throw new ArgumentNullException(nameof(applicationWindowManager));
        _configurationLoader = configurationLoader ?? throw new ArgumentNullException(nameof(configurationLoader));
        _authenticationTypeFactory = authenticationTypeFactory;

        _addCommand = new DelegateCommand((obj) =>
        {
            var viewModel = new ClientEditorWindowViewModel(configurationLoader, applicationWindowManager, authenticationTypeFactory);
            var result = applicationWindowManager1.ShowDialog(viewModel);

            if ( result.HasValue && result.Value )
            {
                AddOrUpdate(viewModel.GetClientConfiguration());
            }
        });
        _deleteCommand = new DelegateCommand((obj) =>
        {

        }, (obj) => SelectedClient != null);
        _startCommand = new DelegateCommand((obj) =>
        {
            
        },(obj) => SelectedClient?.IsStopped ?? false);
        _stopCommand = new DelegateCommand((obj) => { }, (obj) => SelectedClient?.IsRunning ?? false);

        OnLoad();
    }

    private void AddOrUpdate(ClientConfiguration configuration)
    {
        if (configuration == null) throw new ArgumentNullException(nameof(configuration));
        var toUpdate = _configurationLoader.Current.Clients?.FirstOrDefault(cl => cl.Id == configuration.Id);

        if (toUpdate == null)
        {
            // Add 
            _configurationLoader.Current.Add(configuration);
        }
        else
        {
            toUpdate.AuthenticationServiceId = configuration.AuthenticationServiceId;
            toUpdate.ClientTypeId = configuration.ClientTypeId;
            toUpdate.Password = configuration.Password;
            toUpdate.Username = configuration.Username;
            toUpdate.RefreshToken = null;
        }
    }

    private OAuthClientViewModel Create(ClientConfiguration configuration)
    {
        return new OAuthClientViewModel(configuration, _configurationLoader, _authenticationTypeFactory);
    }

    private void OnLoad()
    {
        _configurationLoader.Load();
        var configuration = _configurationLoader.Current;

        //configuration.AuthenticationServers
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
    public override string Title => "OAuth2 Client Tester";
}