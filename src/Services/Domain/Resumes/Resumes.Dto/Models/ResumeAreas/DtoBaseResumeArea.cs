using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.DataTransfer.Models;
using Newtonsoft.Json;
using Resumes.Dto.Models.Geographic;

namespace Resumes.Dto.Models.ResumeAreas
{
    public abstract class DtoBaseResumeArea: DtoEntity
    {
        [JsonProperty("resume_id")]
        public virtual long ResumeId { get; set; }

        [JsonProperty("area")]
        public virtual DtoArea Area { get; set; }

        [JsonProperty("area_id")]
        public virtual long AreaId { get; set; }
    }
}
