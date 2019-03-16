using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.EventBus.Events;
using Dictionaries.Dto.Models.Languages;
using Dictionaries.Dto.Models.Negotiations;
using Dictionaries.Dto.Models.Skills;

namespace Dictionaries.EventBus.Events.Skills
{
    public class SkillsChanged : 
        EntityChangedIntegrationEvent<DtoSkill>
    {
    }
}
