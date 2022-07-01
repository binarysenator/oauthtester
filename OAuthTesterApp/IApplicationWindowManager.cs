using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace OAuthTesterApp;

public interface IApplicationWindowManager
{
    T Create<T>() where T : Page;
    bool? ShowDialogue(Page window);
}