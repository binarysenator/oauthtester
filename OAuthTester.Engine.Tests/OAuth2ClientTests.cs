using System.Net.Http;
using Moq;
using NUnit.Framework;

namespace OAuthTester.Engine.Tests
{
    public class OAuth2ClientTests
    {
        [Test]
        public void OAuth2Client_Construct_ExpectSuccess()
        {
            var mockConfigurationLoader = new Mock<IConfigurationManager>();
            var mockAuthenticationTypeFactory = new Mock<IAuthenticationTypeFactory>();
            var client = new OAuth2Client(new ClientConfiguration(), mockConfigurationLoader.Object, mockAuthenticationTypeFactory.Object);
            Assert.IsNotNull(client.Settings);
            Assert.IsNotNull(client.Status);
            Assert.AreEqual(ClientStatus.Stopped, client.CurrentStatus);
        }
    }
}