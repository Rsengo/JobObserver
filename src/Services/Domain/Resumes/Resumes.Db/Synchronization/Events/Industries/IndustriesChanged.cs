using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Resumes.Db.Dto.Models.Industries;

namespace Resumes.Db.Synchronization.Events.Industries
{
    public class IndustriesChanged : 
        EntityChangedIntegrationEvent<DtoIndustry>
    {
    }
}
