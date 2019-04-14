using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Vacancies.Dto.Models.Geographic;

namespace Vacancies.Synchronization.Events.Geographic
{
    public class AreasChanged : 
        EntityChangedIntegrationEvent<DtoArea>
    {
    }
}
