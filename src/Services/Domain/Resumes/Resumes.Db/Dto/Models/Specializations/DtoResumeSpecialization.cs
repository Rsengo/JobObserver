using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.DataTransfer.Models;
using Newtonsoft.Json;

namespace Resumes.Db.Dto.Models.Specializations
{
    public class DtoResumeSpecialization : DtoEntity
    {
        [JsonProperty("resume_id")]
        public virtual long ResumeId { get; set; }

        [JsonProperty("specialization")]
        public virtual DtoSpecialization Specialization { get; set; }

        [JsonProperty("specialization_id")]
        public virtual long SpecializationId { get; set; }
    }
}
