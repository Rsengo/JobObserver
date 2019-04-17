using BuildingBlocks.DataTransfer.Models;
using Newtonsoft.Json;

namespace Resumes.Db.Dto.Models.Languages
{
    /// <summary>
    ///     Навыки владения каким-либо языком
    /// </summary>
    public class DtoLanguageSkill : DtoEntity
    {
        /// <summary>
        ///     Язык
        /// </summary>
        [JsonProperty("language")]
        public virtual DtoLanguage Language { get; set; }

        /// <summary>
        ///     Id Языка
        /// </summary>
        [JsonProperty("language_id")]
        public virtual long? LanguageId { get; set; }

        /// <summary>
        ///     Уровень
        /// </summary>
        [JsonProperty("level")]
        public virtual DtoLanguageLevel Level { get; set; }

        /// <summary>
        ///     Id Уровня
        /// </summary>
        [JsonProperty("level_id")]
        public virtual long? LevelId { get; set; }

        [JsonProperty("resume_id")]
        public virtual long ResumeId { get; set; }
    }
}