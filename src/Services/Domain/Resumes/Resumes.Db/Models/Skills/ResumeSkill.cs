using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EntityFramework.Models;

namespace Resumes.Db.Models.Skills
{
    public class ResumeSkill : RelationalEntity
    {
        public virtual Resume Resume { get; set; }

        public virtual long ResumeId { get; set; }

        public virtual Skill Skill { get; set; }

        public virtual long SkillId { get; set; }
    }
}
