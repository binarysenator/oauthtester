using System.Runtime.Serialization;

namespace OAuthTester.Engine;

[DataContract]
public class ClientConfiguration
{
    [DataMember(Name = "id")] 
    public Guid Id { get; set; } = Guid.NewGuid();
    [DataMember(Name = "token")]
    public string? Token { get; set; }
    [DataMember(Name = "clientId")]
    public string? ClientId { get; set; }
    [DataMember(Name = "clientSecret")]
    public string? ClientSecret { get; set; }
    [DataMember(Name = "username")]
    public string? Username { get; set; }
    [DataMember(Name = "password")]
    public string? Password { get; set; }
    [DataMember(Name = "authenticationServiceId")]
    public Guid? AuthenticationServiceId { get; set; }
    [DataMember(Name = "clientTypeId")]
    public Guid? ClientTypeId { get; set; }
    [DataMember(Name = "refreshToken")]
    public string? RefreshToken { get; set; }
    [DataMember(Name = "state")] 
    public ClientStatus State { get; set; } = ClientStatus.Stopped;
}