using System.Runtime.Serialization;

namespace OAuthTester.Engine;

[DataContract]
public class AuthenticationServer
{
    [DataMember(Name = "id")]
    public Guid Id { get; set; } = Guid.NewGuid();

    [DataMember(Name = "authenticationUrl")]
    public string? AuthenticationUrl { get; set; }

    [DataMember(Name = "display")]
    public string? DisplayName { get; set; }

    [DataMember(Name = "tokenEndpoint")] 
    public string? TokenEndpoint { get; set; } = "oauth/token";
}