using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Dictionaries.Dto.Models.Educations;

namespace Dictionaries.EventBus.Events.Educations
{
    public class EducationalLevelsChanged : 
        EntityChangedIntegrationEvent<DtoEducationalLevel>
    {
    }
}
