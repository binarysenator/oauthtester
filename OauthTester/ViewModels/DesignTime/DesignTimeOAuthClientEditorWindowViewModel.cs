using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using OAuthTester.ViewModels.Dialogue;

namespace OAuthTester.ViewModels.DesignTime;

public class DesignTimeOAuthClientEditorWindowViewModel : IClientEditorWindowsViewModel
{
    public string Title => "Design Time Client Editor";
    public string? DisplayName { get; set; } = "iOS App (Development)";
    public string? ClientId { get; set; } = "iosappclientid";
    public Guid? AuthenticationServiceId { get; set; }
    public Guid? ClientTypeId { get; set; }
    public Guid? AuthenticationTypeId { get; set; }
    public string? Password { get; set; } = "SausagingIsNeverEasy123!";
    public string? Username { get; set; } = "binarysenator@gmail.com";

    public DesignTimeOAuthClientEditorWindowViewModel()
    {
        AuthenticationServers = new ObservableCollection<AuthenticationServerListItemViewModel>();
        ClientTypes = new ObservableCollection<ClientTypeListItemViewModel>();
        AuthenticationTypes = new ObservableCollection<AuthenticationTypeListItemViewModel>();

        var devId = Guid.NewGuid();
        AuthenticationServers.Add(new AuthenticationServerListItemViewModel() { DisplayName = "Development", Id = devId });

        var authId = Guid.NewGuid();
        AuthenticationTypes.Add(new AuthenticationTypeListItemViewModel() { DisplayName = "Client Secret", Id = devId });
        
        var clientSecretId = Guid.NewGuid();
        ClientTypes.Add(new ClientTypeListItemViewModel() { DisplayName = "Android Client", Id = clientSecretId });
    }

    public ObservableCollection<AuthenticationServerListItemViewModel> AuthenticationServers
    {
        get;
    }

    public ObservableCollection<AuthenticationTypeListItemViewModel> AuthenticationTypes
    {
        get;
    }

    public ObservableCollection<ClientTypeListItemViewModel> ClientTypes
    {
        get;
    }

    public ICommand AddAuthenticationServerCommand
    {
        get { throw new NotImplementedException(); }
    }

    public ICommand AddClientTypeCommand
    {
        get { throw new NotImplementedException(); }
    }

    
}