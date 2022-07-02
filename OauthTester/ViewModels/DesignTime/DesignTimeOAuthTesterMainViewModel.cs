using System.Collections.ObjectModel;
using System.Windows.Input;
using OauthTester.ViewModels;
using OAuthTester.ViewModels.Commands;

namespace OAuthTester.ViewModels.DesignTime;

public class DesignTimeOAuthTesterMainViewModel : IOAuthTesterMainViewMode
{
    private readonly ICommand _availableCommand = new DelegateCommand((obj) => { }, (obj) => true);

    public DesignTimeOAuthTesterMainViewModel()
    {
        var selectedItem = new DesignTimeOAuthClientViewModel() {ClientId = "c", Username = "binarysenator@gmail.com"};
        Clients.Add(new DesignTimeOAuthClientViewModel() { ClientId = "a", Username = "jon.sausage.samwell@gmail.com"});
        Clients.Add(new DesignTimeOAuthClientViewModel() { ClientId = "b", Username = "idris.harding@gmail.com"});
        Clients.Add(selectedItem);
        Clients.Add(new DesignTimeOAuthClientViewModel() { ClientId = "b", Username = "god.minster@easilog.com"});
        SelectedClient = selectedItem;
    }

    public DesignTimeOAuthClientViewModel SelectedClient { get; set; }
    public ObservableCollection<DesignTimeOAuthClientViewModel> Clients { get; } = new ObservableCollection<DesignTimeOAuthClientViewModel>();
    public ICommand StartCommand => _availableCommand;
    public ICommand StopCommand { get; } = new DelegateCommand((obj) => { }, (obj) => false);
    public ICommand AddCommand => _availableCommand;
    public ICommand DeleteCommand => _availableCommand;
    public bool HasSelection => true;
    public string Title => "OAuth2 Authentication Client Tester";
}