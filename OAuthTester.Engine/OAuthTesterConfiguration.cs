using System.Runtime.Serialization;

namespace OAuthTester.Engine;

[DataContract]
public class OAuthTesterConfiguration
{
    private readonly List<AuthenticationServer> _servers = new List<AuthenticationServer>();
    private readonly List<ClientConfiguration> _clients = new List<ClientConfiguration>();

    public OAuthTesterConfiguration() { }

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
}