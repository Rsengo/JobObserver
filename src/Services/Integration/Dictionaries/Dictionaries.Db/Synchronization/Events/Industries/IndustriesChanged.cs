using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Dictionaries.Db.Dto.Models.Industries;

namespace Dictionaries.Db.Synchronization.Events.Industries
{
    public class IndustriesChanged : 
        EntityChangedIntegrationEvent<DtoIndustry>
    {
    }
}
