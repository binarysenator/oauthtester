using System.Windows;
using Redbridge.Linq;

namespace OAuthTester;

public interface IApplicationWindowManager
{
    T Create<T>() where T : Window;
    bool? ShowDialogue(Window window);
}