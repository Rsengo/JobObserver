using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Dictionaries.Db.Dto.Models.Educations;

namespace Dictionaries.Db.Synchronization.Events.Educations
{
    public class EducationalLevelsChanged : 
        EntityChangedIntegrationEvent<DtoEducationalLevel>
    {
    }
}
