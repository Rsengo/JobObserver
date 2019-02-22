using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Events;
using Dictionaries.Dto.Models.Driving;
using Dictionaries.Dto.Models.Educations;

namespace Dictionaries.EventBus.Events.Educations
{
    public class EducationalLevelsUpdated : 
        DictionaryUpdatedIntegrationEvent<DtoEducationalLevel>
    {
        public EducationalLevelsUpdated(IEnumerable<DtoEducationalLevel> entities) : 
            base(entities)
        {
        }
    }
}
