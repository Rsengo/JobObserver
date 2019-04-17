using Newtonsoft.Json;
using BuildingBlocks.DataTransfer.Models;

namespace Login.Db.Dto.Models.Geographic
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