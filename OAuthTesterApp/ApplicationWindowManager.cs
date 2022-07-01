using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Microsoft.Extensions.DependencyInjection;

namespace OAuthTesterApp
{
    public class ApplicationWindowManager : IApplicationWindowManager
    {
        private readonly IServiceProvider _serviceProvider;
        private static Frame AppFrame => ((Window.Current.Content as Frame));

        public ApplicationWindowManager(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public T Create<T>() where T : Page
        {
            var window = _serviceProvider.GetRequiredService<T>();
            return window;
        }

        public bool? ShowDialogue(Page window)
        {
           // return window.Activate();
           return null;
        }
    }
}
