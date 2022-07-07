using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Runtime.Serialization;

namespace OAuthTester.Engine;

[DataContract]
public class OAuthTesterConfiguration
{
    private readonly List<AuthenticationServer> _servers = new List<AuthenticationServer>();
    private readonly List<ClientConfiguration> _clients = new List<ClientConfiguration>();
    private readonly List<ClientType> _clientTypes = new List<ClientType>();
    private readonly IObservable<AuthenticationServer> _serversObservable;
    private readonly IObservable<ClientConfiguration> _clientsObservable;
    private readonly Subject<AuthenticationServer> _serversSubject = new Subject<AuthenticationServer>();
    private readonly Subject<ClientConfiguration> _clientsSubject = new Subject<ClientConfiguration>();

    
    public OAuthTesterConfiguration()
    {
        _serversObservable = Observable.Defer(() => _servers.ToObservable()).Merge(_serversSubject);
        _clientsObservable = Observable.Defer(() => _clients.ToObservable()).Merge(_clientsSubject);
    }

    [DataMember(Name = "clients")]
    public ClientConfiguration[]? Clients { get => _clients.ToArray();
        set
        {
            _clients.Clear();
            if (value != null)
            {
                _clients.AddRange(value);
            }
        }
    }

    [DataMember(Name = "selectedClientId")]
    public Guid? SelectedClientId { get; set; }

    [DataMember(Name = "servers")]
    public AuthenticationServer[]? AuthenticationServers
    {
        get => _servers.ToArray();
        set
        {
            _servers.Clear();
            if (value != null)
            {
                _servers.AddRange(value);
            }
        }
    }

    [DataMember(Name = "clientTypes")]
    public ClientType[]? ClientTypes
    {
        get => _clientTypes.ToArray();
        set
        {
            _clientTypes.Clear();
            if (value != null)
            {
                _clientTypes.AddRange(value);
            }
        }
    }

    public static OAuthTesterConfiguration New()
    {
        return new OAuthTesterConfiguration();
    }

    public void Add(AuthenticationServer authenticationServer)
    {
        _servers.Add(authenticationServer);
    }

    public void Add(ClientConfiguration configuration)
    {
        _clients.Add(configuration);
    }

    public void Add(ClientType configuration)
    {
        _clientTypes.Add(configuration);
    }
}