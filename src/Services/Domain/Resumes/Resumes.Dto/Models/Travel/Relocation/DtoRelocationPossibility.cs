using BuildingBlocks.DataTransfer.Models;
using Newtonsoft.Json;
using Resumes.Dto.Models.Geographic;

namespace Resumes.Dto.Models.Travel.Relocation
{
    /// <summary>
    ///     Возможность переезда
    /// </summary>
    public class DtoRelocationPossibility : DtoEntity
    {
        /// <summary>
        ///     Тип переезда
        /// </summary>
        [JsonProperty("relocation_type")]
        public virtual DtoRelocationType RelocationType { get; set; }

        /// <summary>
        ///     Id Типа переезда
        /// </summary>
        [JsonProperty("relocation_type_id")]
        public virtual long RelocationTypeId { get; set; }

        /// <summary>
        ///     Id Города/страны
        /// </summary>
        [JsonProperty("area_id")]
        public virtual long AreaId { get; set; }

        [JsonProperty("area")]
        public virtual DtoArea Area { get; set; }

        [JsonProperty("resume_id")]
        public virtual long ResumeId { get; set; }
    }
}