using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Resumes.Dto.Models.Travel.Relocation;

namespace Resumes.Synchronization.Events.Travel.Relocation
{
    public class RelocationTypesChanged : 
        EntityChangedIntegrationEvent<DtoRelocationType>
    {
    }
}
