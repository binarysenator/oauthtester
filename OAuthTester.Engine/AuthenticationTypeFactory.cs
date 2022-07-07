using Microsoft.Extensions.DependencyInjection;
using OAuthTester.Engine.AuthenticationTypes;

namespace OAuthTester.Engine;

public class AuthenticationTypeFactory : IAuthenticationTypeFactory
{
    private readonly IServiceProvider _collection;

    public AuthenticationTypeFactory(IServiceProvider collection)
    {
        _collection = collection;
    }

    public AuthenticationType? Create(Guid typeId)
    {
        var services = _collection.GetServices<AuthenticationType>();
        return services.FirstOrDefault(s => s.TypeId == typeId);
    }

    public AuthenticationType[] GetAll()
    {
        var services = _collection.GetServices<AuthenticationType>();
        return services.ToArray();
    }
}