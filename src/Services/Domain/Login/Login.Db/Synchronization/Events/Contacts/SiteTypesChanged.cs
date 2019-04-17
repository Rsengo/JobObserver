using BuildingBlocks.EventBus.Synchronization.Events;
using Login.Db.Dto.Models.Contacts;

namespace Login.Db.Synchronization.Events.Contacts
{
    public class SiteTypesChanged : 
        EntityChangedIntegrationEvent<DtoSiteType>
    {
    }
}
