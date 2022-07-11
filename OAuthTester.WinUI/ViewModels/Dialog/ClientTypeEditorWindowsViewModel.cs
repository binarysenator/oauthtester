using System;
using System.Windows.Input;
using Redbridge.WinUI;
using Redbridge.WinUI.Commands;

namespace OAuthTester.ViewModels.Dialogue
{
    public class ClientTypeEditorWindowsViewModel : WindowViewModel
    {
        private DelegateCommand _okCommand;
        private string? _displayName;
        private string? _secret;
        private string? _clientId;

        public override string Title => "Edit client type";

        public ClientTypeEditorWindowsViewModel()
        {
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

        public Guid Id { get; set; }
    }
}
