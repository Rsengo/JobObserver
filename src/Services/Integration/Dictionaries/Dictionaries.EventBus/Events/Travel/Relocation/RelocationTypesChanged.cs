using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Dictionaries.Dto.Models.Travel.Relocation;

namespace Dictionaries.EventBus.Events.Travel.Relocation
{
    public class RelocationTypesChanged : 
        EntityChangedIntegrationEvent<DtoRelocationType>
    {
    }
}
