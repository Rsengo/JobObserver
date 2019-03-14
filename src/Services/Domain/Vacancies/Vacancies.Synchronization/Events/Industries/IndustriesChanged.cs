using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Vacancies.Dto.Models.Industries;

namespace Vacancies.Synchronization.Events.Industries
{
    public class IndustriesChanged : 
        EntityChangedIntegrationEvent<DtoIndustry>
    {
    }
}
