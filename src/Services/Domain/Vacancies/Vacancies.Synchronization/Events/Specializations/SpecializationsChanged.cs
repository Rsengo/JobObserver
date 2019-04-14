using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Vacancies.Dto.Models.Languages;
using Vacancies.Dto.Models.Negotiations;
using Vacancies.Dto.Models.Specializations;

namespace Vacancies.Synchronization.Events.Specializations
{
    public class SpecializationsChanged : 
        EntityChangedIntegrationEvent<DtoSpecialization>
    {
    }
}
