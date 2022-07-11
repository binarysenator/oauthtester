using System;
using OAuthTester.ViewModels.Dialogue;
using OAuthTester.WinUI.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;
using System.Threading.Tasks;
using OAuthTester.WinUI;

namespace OAuthTester
{
    public class ApplicationWindowManager : IApplicationWindowManager
    {
        private readonly IServiceProvider _serviceProvider;

        public ApplicationWindowManager(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public async Task<ContentDialogResult> ShowDialog(ClientEditorWindowViewModel viewModel)
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            var contentDialog = _serviceProvider.GetRequiredService<ClientEditorWindow>();
            contentDialog.Title = viewModel.Title;
            contentDialog.XamlRoot = mainWindow.Content.XamlRoot;
            contentDialog.PrimaryButtonText = "OK";
            contentDialog.CloseButtonText = "Cancel";
            var result = await contentDialog.ShowAsync();
            return result;
        }

        public bool? ShowDialog(AuthenticationServerEditorWindowViewModel viewModel)
        {
            return null; //return ShowDialog<AuthenticationServerEditorWindow>(viewModel);
        }

        public bool? ShowDialog(ClientTypeEditorWindowsViewModel viewModel)
        {
            return null; //return ShowDialog<ClientTypeEditorWindow>(viewModel);
        }
    }
}
