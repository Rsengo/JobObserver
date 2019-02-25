using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Dictionaries.Dto.Models.Languages;
using Dictionaries.Dto.Models.Negotiations;
using Dictionaries.Dto.Models.Specializations;

namespace Dictionaries.EventBus.Events.Specializations
{
    public class SpecializationsChanged : 
        DictionaryChangedIntegrationEvent<DtoSpecialization>
    {
    }
}
