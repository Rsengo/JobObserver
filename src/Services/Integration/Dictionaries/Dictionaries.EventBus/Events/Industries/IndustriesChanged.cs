using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Dictionaries.Dto.Models.Industries;

namespace Dictionaries.EventBus.Events.Industries
{
    public class IndustriesChanged : 
        EntityChangedIntegrationEvent<DtoIndustrySync>
    {
    }
}
