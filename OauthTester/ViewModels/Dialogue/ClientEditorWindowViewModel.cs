using System;
using System.Collections.ObjectModel;
using System.Reactive.Disposables;
using System.Windows.Input;
using OAuthTester.Engine;
using OauthTester.ViewModels;
using OAuthTester.ViewModels.Commands;
using OAuthTester.ViewModels.DesignTime;

namespace OAuthTester.ViewModels.Dialogue
{
    public class ClientEditorWindowViewModel : ViewModel, IClientEditorWindowsViewModel
    {
        private readonly IConfigurationManager _loader;
        private readonly IApplicationWindowManager _windowManager;
        private readonly IAuthenticationTypeFactory _authenticationTypeFactory;
        private string? _displayName;
        private string? _clientId;
        private string? _username;
        private Guid? _authenticationServiceId;
        private Guid? _authenticationTypeId;
        private Guid? _clientTypeId;
        private string? _password;
        private readonly DelegateCommand _addAuthenticationServerCommand;
        private readonly DelegateCommand _addClientTypeCommand;
        private readonly DelegateCommand _okCommand;
        private readonly CompositeDisposable _compositeDisposable = new();
        public string Title => "Edit client connection";

        public ClientEditorWindowViewModel(IConfigurationManager loader, IApplicationWindowManager windowManager, IAuthenticationTypeFactory authenticationTypeFactory)
        {
            _loader = loader ?? throw new ArgumentNullException(nameof(loader));
            _windowManager = windowManager ?? throw new ArgumentNullException(nameof(windowManager));
            _authenticationTypeFactory = authenticationTypeFactory;

            _okCommand = new DelegateCommand((obj) =>
            {
                DialogResult = true;
            });

            _addAuthenticationServerCommand = new DelegateCommand((obj) =>
            {
                var model = new AuthenticationServerEditorWindowViewModel();
                var outcome = _windowManager.ShowDialog(model);

                if (outcome == null || !outcome.Value) return;
                var server = new AuthenticationServer()
                {
                    Id = model.Id,
                    AuthenticationUrl = model.AuthenticationUrl,
                    Name = model.DisplayName
                };
                _loader.Current.Add(server);
            });

            _addClientTypeCommand = new DelegateCommand((obj) =>
            {
                var model = new ClientTypeEditorWindowsViewModel();
                var outcome = _windowManager.ShowDialog(model);

                if (outcome == null || !outcome.Value) return;
                var clientType = new ClientType()
                {
                    Id = model.Id,
                    ClientId = model.ClientId ?? string.Empty,
                    Name = model.DisplayName ?? "No name",
                };
                _loader.Current.Add(clientType);
            });

            OnConfigure(_loader);

            ConfigureObservables();
        }

        private void ConfigureObservables()
        {
            var configuration = _loader.Current;
            _compositeDisposable.Add(configuration.AuthenticationServersObservable
                //.ObserveOn(DispatcherScheduler)
                .Subscribe(s =>
                {
                    if (s.Type == ChangeType.Added)
                    {
                        AuthenticationServers.Add(AuthenticationServerListItemViewModel.From(s.Item));
                    }
                }));

            _compositeDisposable.Add(configuration.ClientTypesObservable
                //.ObserveOnDispatcher()
                .Subscribe(s =>
                {
                    if (s.Type == ChangeType.Added)
                    {
                        ClientTypes.Add(ClientTypeListItemViewModel.From(s.Item));
                    }
                }));
        }

        private void OnConfigure(IConfigurationManager loader)
        {
            var current = loader.Current;
            //current.AuthenticationServers.ForEach(s => AuthenticationServers.Add(AuthenticationServerListItemViewModel.From(s)));

            var types = _authenticationTypeFactory.GetAll();
            //types.ForEach((type) => AuthenticationTypes.Add(new AuthenticationTypeListItemViewModel() { Id = type.TypeId, DisplayName = type.Name }));
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

        public string? Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        public string? Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public string? ClientId
        {
            get => _clientId;
            set { 
                _clientId = value; 
                OnPropertyChanged();
            }
        }

        public AuthenticationServerListItemViewModel SelectedServer
        {
            get;
            set;
        }

        public AuthenticationTypeListItemViewModel SelectedAuthenticationType { get; set; }

        public Guid? AuthenticationServiceId
        {
            get => _authenticationServiceId;
            set
            {
                _authenticationServiceId = value;
                OnPropertyChanged();
            }
        }

        public Guid? AuthenticationTypeId
        {
            get => _authenticationTypeId;
            set
            {
                _authenticationTypeId = value;
                OnPropertyChanged();
            }
        }


        public Guid? ClientTypeId
        {
            get => _clientTypeId;
            set
            {
                _clientTypeId = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<AuthenticationServerListItemViewModel> AuthenticationServers { get; } = new ObservableCollection<AuthenticationServerListItemViewModel>();
        public ObservableCollection<AuthenticationTypeListItemViewModel> AuthenticationTypes { get; } = new ObservableCollection<AuthenticationTypeListItemViewModel>();
        public ICommand AddAuthenticationServerCommand => _addAuthenticationServerCommand;
        public ICommand AddClientTypeCommand => _addClientTypeCommand;

        public bool? DialogResult { get; set; }
        public ICommand OkCommand => _okCommand;
        public ObservableCollection<ClientTypeListItemViewModel> ClientTypes { get; } = new ObservableCollection<ClientTypeListItemViewModel>();

        public ClientConfiguration GetClientConfiguration()
        {
            return new ClientConfiguration()
            {
                Id = Guid.NewGuid(),
                AuthenticationServiceId = AuthenticationServiceId,
                ClientTypeId = ClientTypeId,
                AuthenticationTypeId = AuthenticationTypeId,
            };
        }
    }
}
