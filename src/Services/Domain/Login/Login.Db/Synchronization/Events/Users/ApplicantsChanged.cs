using BuildingBlocks.EventBus.Synchronization.Events;
using Login.Db.Dto.Models;

namespace Login.Db.Synchronization.Events.Users
{
    public class ApplicantsChanged : 
        EntityChangedIntegrationEvent<DtoUser>
    {
    }
}
