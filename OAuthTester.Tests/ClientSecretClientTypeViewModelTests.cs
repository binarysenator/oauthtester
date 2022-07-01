using NuGet.Frameworks;
using NUnit.Framework;
using OAuthTester.ViewModels.ClientTypes;

namespace OAuthTester.Tests
{
    public class ClientSecretClientTypeViewModelTests
    {
        [Test]
        public void Construct_ClientSecretClientTypeViewModel_ExpectSuccess()
        {
            var viewModel = new ClientSecretAuthenticationTypeViewModel();
            Assert.IsTrue(viewModel.ShowClientId);
            Assert.IsTrue(viewModel.ShowPassword);
            Assert.IsTrue(viewModel.ShowSecret);


        }
    }
}