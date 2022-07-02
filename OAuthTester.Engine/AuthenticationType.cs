using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;

namespace OAuthTester.Engine
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

        protected AuthenticationType (IHttpClientFactory clientFactory, IConfigurationManager configurationManager)
        {
            _configurationManager = configurationManager ?? throw new ArgumentNullException(nameof(configurationManager));
            ClientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));
        }

        public void Configure(ClientConfiguration settings)
        {
            Settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        protected IHttpClientFactory ClientFactory { get; }

        public void Start()
        {
            Status.OnNext(ClientStatus.Starting);

            if (Settings == null)
            {
                Status.OnNext(ClientStatus.Error);
                return;
            }

            // First call can't be done on interval as we don't know the interval yet.
            Server = _configurationManager.Configuration?.AuthenticationServers?.FirstOrDefault(auth => auth.Id == Settings.AuthenticationServiceId);

            if (Server == null || string.IsNullOrWhiteSpace(Server?.AuthenticationUrl) || !Settings.ClientTypeId.HasValue)
            {
                Status.OnNext(ClientStatus.Error);
                return;
            }

            _isRunning = true;
            _authenticationTask = OnStart();
        }

        protected bool IsRunning => _isRunning;

        public IObservable<ClientStatus> ObservableStatus => Status.AsQbservable();
        public ClientStatus CurrentStatus => Status.Value;

        public void Stop()
        {
            OnStop();
        }

        protected abstract Task OnStart();

        protected virtual void OnStop()
        {
            _isRunning = false;
        }
    }
}
