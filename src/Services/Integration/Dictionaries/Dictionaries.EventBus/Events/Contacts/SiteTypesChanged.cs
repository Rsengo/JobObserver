using BuildingBlocks.EventBus.Synchronization.Events;
using Dictionaries.Dto.Models.Contacts;

namespace Dictionaries.EventBus.Events.Contacts
{
    public class SiteTypesChanged : 
        EntityChangedIntegrationEvent<DtoSiteType>
    {
    }
}
