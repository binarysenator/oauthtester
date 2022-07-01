using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Runtime.Serialization;
using Redbridge.Identity;
using Redbridge.Identity.OAuthServer;
using Redbridge.Web.Messaging;
using IHttpClientFactory = System.Net.Http.IHttpClientFactory;

namespace OAuthTester.Engine
{
    public class OAuth2Client
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfigurationLoader _configurationLoader;

        private ClientConfiguration _settings;
        private BehaviorSubject<ClientStatus> _status = new BehaviorSubject<ClientStatus>(ClientStatus.Stopped);

        public OAuth2Client(IHttpClientFactory httpClientFactory, IConfigurationLoader configurationLoader)
        {
            _httpClientFactory = httpClientFactory;
            _configurationLoader = configurationLoader ?? throw new ArgumentNullException(nameof(configurationLoader));
            _settings = new ClientConfiguration();
        }

        public OAuth2Client(IHttpClientFactory httpClientFactory, ClientConfiguration configuration, IConfigurationLoader configurationLoader)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _settings = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _configurationLoader = configurationLoader ?? throw new ArgumentNullException(nameof(configurationLoader));
        }

        public void Configure(ClientConfiguration configuration)
        {
            _settings = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public ClientConfiguration Settings => _settings;

        public async Task Start()
        {
            _status.OnNext(ClientStatus.Starting);

            // First call can't be done on interval as we don't know the interval yet.
            var service = _configurationLoader.Configuration.AuthenticationServers.FirstOrDefault(auth => auth.Id == _settings.AuthenticationServiceId);

            if (service == null || string.IsNullOrWhiteSpace(service?.AuthenticationUrl) )
            {
                _status.OnNext(ClientStatus.Error);
                return;
            }

            var uri = new Uri(new Uri(service.AuthenticationUrl), "oauth/token");
            var data = new OAuthAccessTokenRequestData() { ClientId = _settings.ClientId, ClientSecret = _settings.ClientSecret, Email = _settings.Username, Password = _settings.Password, GrantType = GrantTypes.Password };
            
            var client = _httpClientFactory.CreateClient("OAuthClient");
            var response = await client.PostAsync(uri, new FormUrlEncodedContent(data.AsDictionary()));
            if (response.IsSuccessStatusCode)
            {
                _status.OnNext(ClientStatus.Running);
            }
            else
            {
                _status.OnNext(ClientStatus.Error);
            }
        }



        public void Stop()
        {
                
        }

        public ClientStatus CurrentStatus => _status.Value;
        public IObservable<ClientStatus> Status => _status;

    }
}