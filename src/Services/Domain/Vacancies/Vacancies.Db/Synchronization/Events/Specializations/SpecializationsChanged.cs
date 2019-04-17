using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Vacancies.Db.Dto.Models.Languages;
using Vacancies.Db.Dto.Models.Negotiations;
using Vacancies.Db.Dto.Models.Specializations;

namespace Vacancies.Db.Synchronization.Events.Specializations
{
    public class SpecializationsChanged : 
        EntityChangedIntegrationEvent<DtoSpecialization>
    {
    }
}
