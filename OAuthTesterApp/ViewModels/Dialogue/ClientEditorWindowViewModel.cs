using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using OAuthTester.Engine;
using OauthTester.ViewModels;
using OAuthTester.ViewModels;
using OAuthTester.ViewModels.DesignTime;
using OAuthTesterApp.Dialogues;
using OAuthTesterApp.ViewModels.Commands;

namespace OAuthTesterApp.ViewModels.Dialogue
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
        private DelegateCommand _addAuthenticationServerCommand;
        private DelegateCommand _addClientTypeCommand;
        public string Title => "Edit client connection";

        public ClientEditorWindowViewModel(IConfigurationManager loader, IApplicationWindowManager windowManager)
        {
            _loader = loader ?? throw new ArgumentNullException(nameof(loader));
            _windowManager = windowManager ?? throw new ArgumentNullException(nameof(windowManager));
            _addAuthenticationServerCommand = new DelegateCommand((obj) =>
            {
                var window = _windowManager.Create<AuthenticationServerEditorWindow>();
                var outcome = _windowManager.ShowDialogue(window);
                if (outcome != null)
                {

                }
            });
            _addClientTypeCommand = new DelegateCommand((obj) => { });
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
