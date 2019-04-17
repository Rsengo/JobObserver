using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.DataTransfer.Models;
using Newtonsoft.Json;

namespace Resumes.Db.Dto.Models.Skills
{
    public class DtoResumeSkill : DtoEntity
    {
        [JsonProperty("resume_id")]
        public virtual long ResumeId { get; set; }

        [JsonProperty("skill")]
        public virtual DtoSkill Skill { get; set; }

        [JsonProperty("skill_id")]
        public virtual long SkillId { get; set; }
    }
}
