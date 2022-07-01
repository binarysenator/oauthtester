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
            var mockClientFactory = new Mock<IHttpClientFactory>();
            var mockConfigurationLoader = new Mock<IConfigurationLoader>();
            var client = new OAuth2Client(mockClientFactory.Object, mockConfigurationLoader.Object);
            Assert.IsNotNull(client.Settings);
            Assert.IsNotNull(client.Status);
            Assert.AreEqual(ClientStatus.Stopped, client.CurrentStatus);
        }
    }
}