using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Resumes.Dto.Models.Travel;

namespace Resumes.Synchronization.Events.Travel
{
    public class BusinessTripReadinessChanged : 
        EntityChangedIntegrationEvent<DtoBusinessTripReadiness>
    {
    }
}
