using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.DataTransfer.Models;
using Employers.Dto.Models.EducationalInstitutions;
using Newtonsoft.Json;

namespace Employers.Dto.Models
{
    public class DtoPartners: DtoEntity
    {
        [JsonProperty("employer_id")]
        public virtual long EmployerId { get; set; }

        [JsonProperty("educational_institution")]
        public virtual DtoEducationalInstitution EducationalInstitution { get; set; }

        [JsonProperty("educational_institution_id")]
        public virtual long EducationalInstitutionId { get; set; }
    }
}
