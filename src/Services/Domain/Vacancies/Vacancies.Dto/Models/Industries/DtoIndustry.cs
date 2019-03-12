using System.Collections.Generic;
using BuildingBlocks.DataTransfer.Models;
using Newtonsoft.Json;

namespace Vacancies.Dto.Models.Industries
{
    /// <summary>
    ///     Сфера деятельности
    /// </summary>
    public class DtoIndustry : DtoDictionary
    {
        /// <summary>
        ///     Родитель.
        /// </summary>
        [JsonProperty("parent")]
        public virtual DtoIndustry Parent { get; set; }

        /// <summary>
        ///     Id родителя.
        /// </summary>
        [JsonProperty("parent_id")]
        public virtual long? ParentId { get; set; }
    }
}