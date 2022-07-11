using System.Windows.Input;
using OAuthTester.Engine;

namespace OAuthTester.WinUI.ViewModels.DesignTime;

public class DesignTimeOAuthClientViewModel : IOAuthClientViewModel
{
    public string ClientId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string DisplayName { get; set; }
    public ClientStatus Status => ClientStatus.Running;

    public int RefreshIn => 300;

    public ICommand ToggleStateCommand => throw new System.NotImplementedException();
}