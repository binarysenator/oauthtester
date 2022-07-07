using System;
using System.Windows;
using OAuthTester.Dialogues;
using OAuthTester.ViewModels;
using OAuthTester.ViewModels.Dialogue;

namespace OAuthTester
{
    public class ApplicationWindowManager : IApplicationWindowManager
    {
        private readonly IServiceProvider _serviceProvider;

        public ApplicationWindowManager(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        private bool? ShowDialog<TView> (IWindowViewModel viewModel) where TView: Window, new()
        {
            var window = new TView
            {
                DataContext = viewModel,
                Owner = Application.Current.MainWindow
            };
            
            window.ShowDialog();
            return viewModel.DialogResult;
        }

        public bool? ShowDialog(ClientEditorWindowViewModel viewModel)
        {
            return ShowDialog<ClientEditorWindow>(viewModel);
        }

        public bool? ShowDialog(AuthenticationServerEditorWindowViewModel viewModel)
        {
            return ShowDialog<AuthenticationServerEditorWindow>(viewModel);
        }

        public bool? ShowDialog(ClientTypeEditorWindowsViewModel viewModel)
        {
            return ShowDialog<ClientTypeEditorWindow>(viewModel);
        }
    }
}
