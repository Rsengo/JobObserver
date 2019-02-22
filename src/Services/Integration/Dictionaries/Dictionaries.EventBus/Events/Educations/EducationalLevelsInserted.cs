using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Events;
using Dictionaries.Dto.Models.Educations;

namespace Dictionaries.EventBus.Events.Educations
{
    public class EducationalLevelsInserted : 
        DictionaryInsertedIntegrationEvent<DtoEducationalLevel>
    {
        public EducationalLevelsInserted(IEnumerable<DtoEducationalLevel> entities) : 
            base(entities)
        {
        }
    }
}
