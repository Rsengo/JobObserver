using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Vacancies.Db.Dto.Models.Languages;
using Vacancies.Db.Dto.Models.Negotiations;
using Vacancies.Db.Dto.Models.Skills;

namespace Vacancies.Db.Synchronization.Events.Skills
{
    public class SkillsChanged : 
        EntityChangedIntegrationEvent<DtoSkill>
    {
    }
}
