using BuildingBlocks.EventBus.Synchronization.Events;
using Login.Dto.Models;

namespace Login.Synchronization.Events.Users
{
    public class UsersChanged : 
        EntityChangedIntegrationEvent<DtoUser>
    {
    }
}
