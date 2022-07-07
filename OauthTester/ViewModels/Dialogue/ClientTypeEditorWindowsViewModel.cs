using System;
using System.Windows.Input;
using OauthTester.ViewModels;
using OAuthTester.ViewModels.Commands;

namespace OAuthTester.ViewModels.Dialogue
{
    public class ClientTypeEditorWindowsViewModel : WindowViewModel
    {
        private readonly IApplicationWindowManager _windowManager;
        private DelegateCommand _okCommand;
        private string? _displayName;
        private string? _secret;
        private string? _clientId;

        public override string Title => "Edit client type";

        public ClientTypeEditorWindowsViewModel(IApplicationWindowManager windowManager)
        {
            _windowManager = windowManager ?? throw new ArgumentNullException(nameof(windowManager));
            _okCommand = new DelegateCommand((obj) =>
            {
                DialogResult = true;
            });
        }

        public ICommand OKCommand => _okCommand;

        public string? DisplayName
        {
            get => _displayName;
            set
            {
                _displayName = value;
                OnPropertyChanged();
            }
        }

        public string? Secret
        {
            get => _secret;
            set
            {
                _secret = value;
                OnPropertyChanged();
            }
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
    }
}
