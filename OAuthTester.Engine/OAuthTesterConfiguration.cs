using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Runtime.Serialization;

namespace OAuthTester.Engine;

[DataContract]
public class OAuthTesterConfiguration
{
    private readonly List<AuthenticationServer> _servers = new();
    private readonly List<ClientConfiguration> _clients = new();
    private readonly List<ClientType> _clientTypes = new();

    private readonly Subject<Change<AuthenticationServer>> _serversSubject = new();
    private readonly Subject<Change<ClientConfiguration>> _clientsSubject = new();
    private readonly Subject<Change<ClientType>> _clientTypesSubject = new();
    
    public OAuthTesterConfiguration()
    {
        AuthenticationServersObservable = Observable.Defer(() => _servers.ToObservable().Select(s => new Change<AuthenticationServer>())).Merge(_serversSubject);
        ClientsObservable = Observable.Defer(() => _clients.ToObservable().Select(s => new Change<ClientConfiguration>())).Merge(_clientsSubject);
        ClientTypesObservable = Observable.Defer(() => _clientTypes.ToObservable().Select(s => new Change<ClientType>())).Merge(_clientTypesSubject);
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

    [IgnoreDataMember]
    public IObservable<Change<AuthenticationServer>> AuthenticationServersObservable { get; }
    [IgnoreDataMember]
    public IObservable<Change<ClientConfiguration>> ClientsObservable { get; }
    [IgnoreDataMember]
    public IObservable<Change<ClientType>> ClientTypesObservable { get; }

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
        _serversSubject.OnNext(Change.Add(authenticationServer));
    }

    public void Add(ClientConfiguration configuration)
    {
        _clients.Add(configuration);
        _clientsSubject.OnNext(Change.Add(configuration));
    }

    public void Add(ClientType configuration)
    {
        _clientTypes.Add(configuration);
        _clientTypesSubject.OnNext(Change.Add(configuration));
    }
}