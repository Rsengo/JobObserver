using BuildingBlocks.EventBus.Synchronization.Events;
using Dictionaries.Db.Dto.Models.Contacts;

namespace Dictionaries.Db.Synchronization.Events.Contacts
{
    public class SiteTypesChanged : 
        EntityChangedIntegrationEvent<DtoSiteType>
    {
    }
}
