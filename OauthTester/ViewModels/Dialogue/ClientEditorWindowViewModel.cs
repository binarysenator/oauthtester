using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using OAuthTester.Dialogues;
using OAuthTester.Engine;
using OauthTester.ViewModels;
using OAuthTester.ViewModels.Commands;
using OAuthTester.ViewModels.DesignTime;
using Redbridge;

namespace OAuthTester.ViewModels.Dialogue
{
    public class ClientEditorWindowViewModel : ViewModel, IClientEditorWindowsViewModel
    {
        private readonly IConfigurationManager _loader;
        private readonly IApplicationWindowManager _windowManager;
        private string? _displayName;
        private string? _clientId;
        private Guid? _authenticationServiceId;
        private Guid? _authenticationTypeId;
        private Guid? _clientTypeId;
        private string? _password;
        private readonly DelegateCommand _addAuthenticationServerCommand;
        private readonly DelegateCommand _addClientTypeCommand;
        public string Title => "Edit client connection";

        public ClientEditorWindowViewModel(IConfigurationManager loader, IApplicationWindowManager windowManager)
        {
            _loader = loader ?? throw new ArgumentNullException(nameof(loader));
            OnConfigure(_loader);
            _windowManager = windowManager ?? throw new ArgumentNullException(nameof(windowManager));
            _addAuthenticationServerCommand = new DelegateCommand((obj) =>
            {
                var window = _windowManager.Create<AuthenticationServerEditorWindow>();
                var outcome = _windowManager.ShowDialogue(window);
                if (outcome != null && outcome.Value )
                {
                    var server = new AuthenticationServer()
                    {
                        Id = window.Model.Id,
                        AuthenticationUrl = window.Model.AuthenticationUrl,
                        DisplayName = window.Model.DisplayName
                    };
                    _loader.Configuration.Add(server);
                    AuthenticationServers.Add(AuthenticationServerListItemViewModel.From(server));
                }
            });
            _addClientTypeCommand = new DelegateCommand((obj) => { });
        }

        private void OnConfigure(IConfigurationManager loader)
        {
            var current = loader.Configuration;
            current.AuthenticationServers.ForEach(s => AuthenticationServers.Add(AuthenticationServerListItemViewModel.From(s)));
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
        public ObservableCollection<ClientTypeListItemViewModel> ClientTypes { get; } = new ObservableCollection<ClientTypeListItemViewModel>();
    }
}
