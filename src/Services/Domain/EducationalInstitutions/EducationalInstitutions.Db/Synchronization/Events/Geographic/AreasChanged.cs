using BuildingBlocks.EventBus.Synchronization.Events;
using EducationalInstitutions.Db.Dto.Models.Geographic;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationalInstitutions.Db.Synchronization.Events.Geographic
{
    public class AreasChanged : 
        EntityChangedIntegrationEvent<DtoArea>
    {
    }
}
