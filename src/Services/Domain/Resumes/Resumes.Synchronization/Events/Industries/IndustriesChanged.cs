using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Resumes.Dto.Models.Industries;

namespace Resumes.Synchronization.Events.Industries
{
    public class IndustriesChanged : 
        EntityChangedIntegrationEvent<DtoIndustry>
    {
    }
}
