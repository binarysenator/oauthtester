using System.Windows.Input;
using OAuthTester.Engine;
using Redbridge.Identity;

namespace OauthTester.ViewModels;

public interface IOAuthClientViewModel
{
    string? ClientId { get; }
    string? Username { get; }
    string? Password { get; }
    string? DisplayName { get; }
    ClientStatus Status { get; }
    ICommand ToggleStateCommand { get; }
}