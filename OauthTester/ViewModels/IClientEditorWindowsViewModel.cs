using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using OAuthTester.ViewModels.DesignTime;
using OAuthTester.ViewModels.Dialogue;

namespace OAuthTester.ViewModels;

public interface IClientEditorWindowsViewModel : IWindowViewModel
{
    string? DisplayName { get; set; }
    string? ClientId { get; set; }
    string? Password { get; set; }
    string? Username { get; set; }
    Guid? AuthenticationServiceId { get; set; }
    Guid? AuthenticationTypeId { get; set; }
    Guid? ClientTypeId { get; set; }
    ObservableCollection<AuthenticationServerListItemViewModel> AuthenticationServers { get; }
    ObservableCollection<ClientTypeListItemViewModel> ClientTypes { get; }
    ObservableCollection<AuthenticationTypeListItemViewModel> AuthenticationTypes { get; }
    ICommand AddAuthenticationServerCommand { get; }
    ICommand AddClientTypeCommand { get; }
    bool? DialogResult { get; }
    ICommand OkCommand { get; }
}