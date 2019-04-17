using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Resumes.Db.Dto.Models.Travel;

namespace Resumes.Db.Synchronization.Events.Travel
{
    public class TravelTimesChanged : 
        EntityChangedIntegrationEvent<DtoTravelTime>
    {
    }
}
