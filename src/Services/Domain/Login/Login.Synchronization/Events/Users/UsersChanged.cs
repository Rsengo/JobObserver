using BuildingBlocks.EventBus.Synchronization.Events;
using Login.Db.Models;

namespace Login.Synchronization.Events.Users
{
    public class UsersChanged : 
        EntityChangedIntegrationEvent<User>
    {
    }
}
