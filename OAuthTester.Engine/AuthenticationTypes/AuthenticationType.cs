using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace OAuthTester.Engine.AuthenticationTypes
{
    public abstract class AuthenticationType
    {
        private readonly IConfigurationManager _configurationManager;
        protected readonly BehaviorSubject<ClientStatus> Status = new BehaviorSubject<ClientStatus>(ClientStatus.Stopped);
        public abstract Guid TypeId { get; }
        public abstract string Name { get; }
        protected AuthenticationServer? Server { get; private set; }
        protected ClientConfiguration? Settings { get; private set; }
        private Task? _authenticationTask;
        private bool _isRunning = false;

        protected AuthenticationType(IHttpClientFactory clientFactory, IConfigurationManager configurationManager)
        {
            _configurationManager = configurationManager ?? throw new ArgumentNullException(nameof(configurationManager));
            ClientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));
        }

        public void Configure(ClientConfiguration settings)
        {
            Settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        protected IHttpClientFactory ClientFactory { get; }
        protected OAuthTesterConfiguration Configuration => _configurationManager.Current;

        public void Start()
        {
            Status.OnNext(ClientStatus.Starting);

            if (Settings == null)
            {
                Status.OnNext(ClientStatus.Error);
                return;
            }

            // First call can't be done on interval as we don't know the interval yet.
            Server = _configurationManager.Current?.AuthenticationServers?.FirstOrDefault(auth => auth.Id == Settings.AuthenticationServiceId);

            if (Server == null || string.IsNullOrWhiteSpace(Server?.AuthenticationUrl) || !Settings.ClientTypeId.HasValue)
            {
                Status.OnNext(ClientStatus.Error);
                return;
            }

            _isRunning = true;
            var clientType = GetClientType(Settings.ClientTypeId.Value);
            _authenticationTask = OnStart(clientType);
        }

        protected virtual ClientType GetClientType(Guid clientTypeId)
        {
            var type = Configuration.ClientTypes?.FirstOrDefault(ct => ct.Id == clientTypeId);
            if (type == null)
            {
                throw new UnknownClientTypeException(clientTypeId);
            }
            return type;
        }

        protected bool IsRunning => _isRunning;

        public IObservable<ClientStatus> ObservableStatus => Status.AsQbservable();
        public ClientStatus CurrentStatus => Status.Value;

        public void Stop()
        {
            OnStop();
        }

        protected abstract Task OnStart(ClientType clientType);

        protected virtual void OnStop()
        {
            _isRunning = false;
        }
    }
}
