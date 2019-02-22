using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Events;
using Dictionaries.Dto.Models.Driving;
using Dictionaries.Dto.Models.Educations;

namespace Dictionaries.EventBus.Events.Educations
{
    public class EducationalLevelsDeleted : DictionaryDeletedIntegrationEvent
    {
        public EducationalLevelsDeleted(IEnumerable<long> ids) : base(ids)
        {
        }
    }
}
