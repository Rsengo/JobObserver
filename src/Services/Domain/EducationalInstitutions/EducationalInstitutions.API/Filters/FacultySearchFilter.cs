using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EducationalInstitutions.API.Filters
{
    public class FacultySearchFilter : SearchFilter
    {
        [JsonProperty("educational_institution_id")]
        public long EducationalInstitutionId { get; set; }
    }
}
