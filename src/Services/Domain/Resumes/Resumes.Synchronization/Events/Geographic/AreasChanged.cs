using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Resumes.Dto.Models.Geographic;

namespace Resumes.Synchronization.Events.Geographic
{
    public class AreasChanged : 
        EntityChangedIntegrationEvent<DtoArea>
    {
    }
}
