using BuildingBlocks.DataTransfer.Models;
using Newtonsoft.Json;

namespace Employers.Db.Dto.Models
{
    /// <summary>
    ///     Отдел
    /// </summary>
    public class DtoDepartment : DtoDictionary
    {
        /// <summary>
        ///     Id Организации
        /// </summary>
        [JsonProperty("organization_id")]
        public virtual long OrganizationId { get; set; }

        [JsonProperty("description")]
        public virtual string Description { get; set; }
    }
}