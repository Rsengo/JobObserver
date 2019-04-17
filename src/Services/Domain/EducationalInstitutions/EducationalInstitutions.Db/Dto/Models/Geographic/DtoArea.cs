using System.Collections.Generic;
using BuildingBlocks.DataTransfer.Models;
using Newtonsoft.Json;

namespace EducationalInstitutions.Db.Dto.Models.Geographic
{
    /// <summary>
    ///     Город/страна
    /// </summary>
    public class DtoArea : DtoDictionary
    {
        /// <summary>
        ///     Родитель
        /// </summary>
        [JsonProperty("parent")]
        public virtual DtoArea Parent { get; set; }

        /// <summary>
        ///     Id Родителя
        /// </summary>
        [JsonProperty("parent_id")]
        public virtual long? ParentId { get; set; }
    }
}