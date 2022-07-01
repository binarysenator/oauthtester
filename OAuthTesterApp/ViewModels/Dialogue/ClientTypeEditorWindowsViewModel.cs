using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OauthTester.ViewModels;

namespace OAuthTester.ViewModels.Dialogue
{
    public class ClientTypeEditorWindowsViewModel : WindowViewModel
    {
        private string? _displayName;
        private string? _secret;
        private string? _clientId;

        public override string Title => "Edit client type";

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
