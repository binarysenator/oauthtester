using System.Windows.Input;
using OAuthTester.Engine;

namespace OAuthTester.WinUI.ViewModels;

public interface IOAuthClientViewModel
{
    string? ClientId { get; }
    string? Username { get; }
    string? Password { get; }
    string? DisplayName { get; }
    ClientStatus Status { get; }
    ICommand ToggleStateCommand { get; }
}