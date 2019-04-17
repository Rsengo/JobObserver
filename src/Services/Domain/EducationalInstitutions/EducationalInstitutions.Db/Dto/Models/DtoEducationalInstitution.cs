using System.Collections.Generic;
using EducationalInstitutions.Db.Dto.Models.Geographic;
using Newtonsoft.Json;

namespace EducationalInstitutions.Db.Dto.Models
{
    /// <summary>
    ///     Образовательное учреждение
    /// </summary>
    public class DtoEducationalInstitution : DtoBaseOrganization
    {
        /// <summary>
        ///     Id Города
        /// </summary>
        [JsonProperty("area_id")]
        public virtual long? AreaId { get; set; }

        /// <summary>
        ///     Город.
        /// </summary>
        [JsonProperty("area")]
        public virtual DtoArea Area { get; set; }

        /// <summary>
        ///     Факультеты
        /// </summary>
        [JsonProperty("faculties")]
        public virtual ICollection<DtoFaculty> Faculties { get; set; }
    }
}