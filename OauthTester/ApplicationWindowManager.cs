using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Accessibility;
using Microsoft.Extensions.DependencyInjection;

namespace OAuthTester
{
    public class ApplicationWindowManager : IApplicationWindowManager
    {
        private readonly IServiceProvider _serviceProvider;

        public ApplicationWindowManager(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public T Create<T>() where T : Window
        {
            var window = _serviceProvider.GetRequiredService<T>();
            return window;
        }

        public bool? ShowDialogue(Window window)
        {
            return window.ShowDialog();
        }
    }
}
