using System;
using OAuthTester.Engine;

namespace OAuthTester.ViewModels.DesignTime;

public class ClientTypeListItemViewModel
{
    public Guid Id { get; set; }
    public string DisplayName { get; set; } = "Unnamed";

    public static ClientTypeListItemViewModel From(ClientType objItem)
    {
        return new ClientTypeListItemViewModel()
        {
            DisplayName = objItem.Name,
            Id = objItem.Id,
        };
    }
}