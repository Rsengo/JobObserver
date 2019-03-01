using BuildingBlocks.DataTransfer.Models;
using Newtonsoft.Json;

namespace Employers.Dto.Models
{
    /// <summary>
    ///     Отдел
    /// </summary>
    public class DtoDepartment : DtoDictionary
    {
        /// <summary>
        ///     Организация
        /// </summary>
        [JsonProperty("organization")]
        public virtual DtoEmployer Organization { get; set; }

        /// <summary>
        ///     Id Организации
        /// </summary>
        [JsonProperty("organization_id")]
        public virtual long OrganizationId { get; set; }
    }
}