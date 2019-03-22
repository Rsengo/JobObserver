using System;
using System.Collections.Generic;
using System.Text;

namespace Login.Synchronization.Events.Contacts
{
    using BuildingBlocks.EventBus.Synchronization.Events;

    using Login.Dto.Models.Contacts;

    public class SiteTypesChanged : 
        EntityChangedIntegrationEvent<DtoSiteType>
    {
    }
}
