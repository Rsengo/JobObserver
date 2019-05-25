using BuildingBlocks.DataTransfer.Models;
using Newtonsoft.Json;

namespace Vacancies.Db.Dto.Models.BrandedTemplates
{ 
    /// <summary>
    ///     Брендированный шаблон
    /// </summary>
    public class DtoBrandedTemplate : DtoEntity
    {
        /// <summary>
        ///     Название.
        /// </summary>
        [JsonProperty("name")]
        public virtual string Name { get; set; }

        /// <summary>
        ///     HTML шаблон
        /// </summary>
        [JsonProperty("text")]
        public virtual string Text { get; set; }

        [JsonProperty("vacancy_id")]
        public virtual long VacancyId { get; set; }
    }
}