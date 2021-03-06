using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using OAuthTester;
using OAuthTester.Dialogues;
using OAuthTester.Engine;
using OAuthTester.Engine.AuthenticationTypes;
using OAuthTester.ViewModels.Dialogue;

namespace OauthTester
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
            services.AddTransient<ClientEditorWindow>();
            services.AddTransient<AuthenticationServerEditorWindow>();
            services.AddTransient<ClientTypeEditorWindow>();

            services.AddSingleton<IApplicationWindowManager, ApplicationWindowManager>();
            services.AddSingleton<IAuthenticationTypeFactory, AuthenticationTypeFactory>();

            services.AddTransient<AuthenticationType, ClientSecretAuthenticationType>();
            services.AddSingleton<OAuthTesterMainViewModel>();
            services.AddTransient<ClientEditorWindowViewModel>();
            services.AddTransient<ClientTypeEditorWindowsViewModel>();
            services.AddTransient<AuthenticationServerEditorWindowViewModel>();

            services.AddHttpClient("OAuthClient");
            services.AddSingleton<IConfigurationManager, ConfigurationLoader>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            var configurationLoader = _serviceProvider.GetRequiredService<IConfigurationManager>();
            configurationLoader.Save();
            base.OnExit(e);
        }
    }
}
