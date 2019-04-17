using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Dictionaries.Db.Dto.Models.Languages;
using Dictionaries.Db.Dto.Models.Negotiations;
using Dictionaries.Db.Dto.Models.Specializations;

namespace Dictionaries.Db.Synchronization.Events.Specializations
{
    public class SpecializationsChanged : 
        EntityChangedIntegrationEvent<DtoSpecialization>
    {
    }
}
