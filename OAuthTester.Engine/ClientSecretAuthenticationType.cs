using Redbridge.Identity;

namespace OAuthTester.Engine;

public class ClientSecretAuthenticationType : AuthenticationType
{
    public static Guid AuthenticationTypeId = Guid.Parse("E5D65900-633E-4E55-A44A-925909D8FE16");
    public override Guid TypeId => AuthenticationTypeId;
    public override string Name => "Client Secret";
    public ClientSecretAuthenticationType(IHttpClientFactory clientFactory, IConfigurationManager configurationManager) : base(clientFactory, configurationManager) { }

    protected override async Task OnStart()
    {
        var uri = new Uri(new Uri(Server.AuthenticationUrl), Server.TokenEndpoint ?? string.Empty);
        var data = new OAuthAccessTokenRequestData() { ClientId = Settings.ClientId, ClientSecret = Settings.ClientSecret, Email = Settings.Username, Password = Settings.Password, GrantType = GrantTypes.Password };

        var client = ClientFactory.CreateClient("OAuthClient");
        var response = await client.PostAsync(uri, new FormUrlEncodedContent(data.AsDictionary()));
        if (response.IsSuccessStatusCode)
        {
            Status.OnNext(ClientStatus.Running);
        }
        else
        {
            Status.OnNext(ClientStatus.Error);
        }
    }
}