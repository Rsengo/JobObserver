using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.DataTransfer.Models;
using BuildingBlocks.EntityFramework.Models;
using Newtonsoft.Json;

namespace EducationalInstitutions.Db.Dto.Models.Synonyms
{
    public class DtoEducationalInstitutionSynonyms: DtoDictionary
    {
        [JsonProperty("educational_institution_id")]
        public virtual long EducationalInstitutionId { get; set; }
    }
}
