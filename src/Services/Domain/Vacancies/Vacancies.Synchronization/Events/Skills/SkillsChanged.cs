using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Vacancies.Dto.Models.Languages;
using Vacancies.Dto.Models.Negotiations;
using Vacancies.Dto.Models.Skills;

namespace Vacancies.Synchronization.Events.Skills
{
    public class SkillsChanged : 
        EntityChangedIntegrationEvent<DtoSkill>
    {
    }
}
