using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.DataTransfer.Models;
using BuildingBlocks.EntityFramework.Models;
using Newtonsoft.Json;

namespace Vacancies.Db.Dto.Models.Skills
{
    public class DtoVacancySkill : DtoEntity
    {
        [JsonProperty("vacancy_id")]
        public virtual long VacancyId { get; set; }

        [JsonProperty("skill")]
        public virtual DtoSkill Skill { get; set; }

        [JsonProperty("skill_id")]
        public virtual long SkillId { get; set; }
    }
}
