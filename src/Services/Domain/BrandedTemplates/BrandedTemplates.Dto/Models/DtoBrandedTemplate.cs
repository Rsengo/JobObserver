using Newtonsoft.Json;

namespace BrandedTemplates.Dto.Models
{ 
    /// <summary>
    ///     Брендированный шаблон
    /// </summary>
    public class DtoBrandedTemplate
    {

        /// <summary>
        ///     Id сущности.
        /// </summary>
        [JsonProperty("id")]
        public virtual long Id { get; set; }

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
    }
}