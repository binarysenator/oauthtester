using System.Runtime.Serialization;

namespace OAuthTester.Engine;

[DataContract]
public class OAuthTesterConfiguration
{
    public OAuthTesterConfiguration()
    {
        Clients = Array.Empty<ClientConfiguration>();
    }

    [DataMember(Name = "clients")]
    public ClientConfiguration[] Clients { get; set; }

    [DataMember(Name = "selectedClientId")]
    public Guid? SelectedClientId { get; set; }

    [DataMember(Name = "servers")]
    public AuthenticationServer[] AuthenticationServers { get; set; }

    public static OAuthTesterConfiguration New()
    {
        return new OAuthTesterConfiguration();
    }
}