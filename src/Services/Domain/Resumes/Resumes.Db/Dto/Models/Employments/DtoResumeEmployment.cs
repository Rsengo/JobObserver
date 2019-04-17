using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.DataTransfer.Models;
using Newtonsoft.Json;

namespace Resumes.Db.Dto.Models.Employments
{
    public class DtoResumeEmployment : DtoEntity
    {
        [JsonProperty("resume_id")]
        public virtual long ResumeId { get; set; }

        [JsonProperty("employment")]
        public virtual DtoEmployment Employment { get; set; }

        [JsonProperty("employment_id")]
        public virtual long EmploymentId { get; set; }
    }
}
