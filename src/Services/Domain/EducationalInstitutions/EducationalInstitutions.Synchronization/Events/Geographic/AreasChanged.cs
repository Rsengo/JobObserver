using BuildingBlocks.EventBus.Synchronization.Events;
using EducationalInstitutions.Dto.Models.Geographic;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationalInstitutions.Synchronization.Events.Geographic
{
    public class AreasChanged : 
        EntityChangedIntegrationEvent<DtoArea>
    {
    }
}
