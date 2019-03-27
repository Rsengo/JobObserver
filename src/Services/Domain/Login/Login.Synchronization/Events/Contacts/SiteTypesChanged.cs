using BuildingBlocks.EventBus.Synchronization.Events;
using Login.Dto.Models.Contacts;

namespace Login.Synchronization.Events.Contacts
{
    public class SiteTypesChanged : 
        EntityChangedIntegrationEvent<DtoSiteType>
    {
    }
}
