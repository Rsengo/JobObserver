using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EntityFramework.Models;

namespace Vacancies.Db.Models.Skills
{
    public class VacancySkill : RelationalEntity
    {
        public virtual Vacancy Vacancy { get; set; }

        public virtual long VacancyId { get; set; }

        public virtual Skill Skill { get; set; }

        public virtual long SkillId { get; set; }
    }
}
