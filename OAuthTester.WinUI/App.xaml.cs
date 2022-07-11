using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using OAuthTester.Engine;
using OAuthTester.Engine.AuthenticationTypes;
using OAuthTester.ViewModels.Dialogue;
using OAuthTester.WinUI.Views;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace OAuthTester.WinUI
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            var services = new ServiceCollection();
            this.InitializeComponent();
            ConfigureServices(services);

             _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
            services.AddTransient<ClientEditorWindow>();
            //services.AddTransient<AuthenticationServerEditorWindow>();
            //services.AddTransient<ClientTypeEditorWindow>();

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

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            m_window = mainWindow;
            m_window.Activate();
        }

        private Window m_window;
    }
}
