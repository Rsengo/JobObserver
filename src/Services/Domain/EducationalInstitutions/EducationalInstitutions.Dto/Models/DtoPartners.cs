using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.DataTransfer.Models;
using Newtonsoft.Json;

namespace EducationalInstitutions.Dto.Models
{
    public class DtoPartners: DtoEntity
    {
        [JsonProperty("employer_id")]
        public virtual long EmployerId { get; set; }

        [JsonProperty("educational_institution_id")]
        public virtual long EducationalInstitutionId { get; set; }
    }
}
