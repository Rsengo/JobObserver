using System.Collections.Generic;
using Newtonsoft.Json;

namespace EducationalInstitutions.Dto.Models
{
    /// <summary>
    ///     Факультет
    /// </summary>
    public class DtoFaculty : DtoBaseOrganization
    {
        /// <summary>
        ///     Образовательное учреждение
        /// </summary>
        [JsonProperty("educational_institution")]
        public virtual DtoEducationalInstitution EducationalInstitution { get; set; }

        /// <summary>
        ///     Id Образовательного учреждения
        /// </summary>
        [JsonProperty("educational_institution_id")]
        public virtual long EducationalInstitutionId { get; set; }
    }
}