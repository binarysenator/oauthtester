using OAuthTester.Engine.AuthenticationTypes;
using OAuthTester.Engine.Exceptions;

namespace OAuthTester.Engine
{
    public class OAuth2Client
    {
        private readonly IConfigurationManager _configurationLoader;
        private readonly IAuthenticationTypeFactory _authenticationTypeFactory;
        private ClientConfiguration _settings;
        private AuthenticationType? _authenticationType;

        public OAuth2Client(ClientConfiguration configuration, IConfigurationManager configurationLoader, IAuthenticationTypeFactory authenticationTypeFactory)
        {
            _settings = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _configurationLoader = configurationLoader ?? throw new ArgumentNullException(nameof(configurationLoader));
            _authenticationTypeFactory = authenticationTypeFactory ?? throw new ArgumentNullException(nameof(authenticationTypeFactory));
        }

        public void Configure(ClientConfiguration configuration)
        {
            _settings = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public ClientConfiguration Settings => _settings;

        public void Start()
        {
            if (!_settings.AuthenticationTypeId.HasValue)
            {
                throw new OAuthEngineException("Unable to create client, the authentication type has not been supplied.");
            }

            _authenticationType = _authenticationTypeFactory.Create(_settings.AuthenticationTypeId.Value);
            if (_authenticationType == null)
            {
                throw new OAuthEngineException($"Unable to create with type {_settings.AuthenticationTypeId.Value}");
            }

            _authenticationType.Configure(Settings);
            _authenticationType.Start();
        }

        public void Stop()
        {   
            _authenticationType?.Stop();
        }

        public ClientStatus CurrentStatus => _authenticationType?.CurrentStatus ?? ClientStatus.Unavailable;
        public IObservable<ClientStatus>? Status => _authenticationType?.ObservableStatus;

    }
}