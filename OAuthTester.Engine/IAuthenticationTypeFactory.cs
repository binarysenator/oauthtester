using OAuthTester.Engine.AuthenticationTypes;

namespace OAuthTester.Engine;

public interface IAuthenticationTypeFactory
{
    AuthenticationType? Create(Guid typeId);
    AuthenticationType[] GetAll();
}