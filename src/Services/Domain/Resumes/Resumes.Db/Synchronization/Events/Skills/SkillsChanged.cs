using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EventBus.Synchronization.Events;
using Resumes.Db.Dto.Models.Languages;
using Resumes.Db.Dto.Models.Negotiations;
using Resumes.Db.Dto.Models.Skills;

namespace Resumes.Db.Synchronization.Events.Skills
{
    public class SkillsChanged : 
        EntityChangedIntegrationEvent<DtoSkill>
    {
    }
}
