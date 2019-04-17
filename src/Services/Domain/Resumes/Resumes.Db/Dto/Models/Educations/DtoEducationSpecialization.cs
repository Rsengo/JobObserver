using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.DataTransfer.Models;
using Newtonsoft.Json;
using Resumes.Db.Dto.Models.Specializations;

namespace Resumes.Db.Dto.Models.Educations
{
    public class DtoEducationSpecialization : DtoEntity
    {
        [JsonProperty("education_id")]
        public virtual long EducationId { get; set; }

        [JsonProperty("specialization")]
        public virtual DtoSpecialization Specialization { get; set; }

        [JsonProperty("specialization_id")]
        public virtual long SpecializationId { get; set; }
    }
}
