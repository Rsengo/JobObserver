using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Dictionaries.Db.Dto.Models.Travel.Relocation;

namespace Dictionaries.Db.Synchronization.Events.Travel.Relocation
{
    public class RelocationTypesChanged : 
        EntityChangedIntegrationEvent<DtoRelocationType>
    {
    }
}
