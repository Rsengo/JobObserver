using BuildingBlocks.DataTransfer.Models;
using Newtonsoft.Json;

namespace Resumes.Dto.Models.Salaries
{
    /// <summary>
    ///     Заработная плата
    /// </summary>
    public class DtoSalary : DtoEntity
    {
        /// <summary>
        ///     Валюта
        /// </summary>
        [JsonProperty("currency")]
        public virtual DtoCurrency Currency { get; set; }

        /// <summary>
        ///     Id Валюты
        /// </summary>
        [JsonProperty("currency_id")]
        public virtual long? CurrencyId { get; set; }

        /// <summary>
        ///     Нижняя граница
        /// </summary>
        [JsonProperty("from")]
        public virtual decimal From { get; set; }

        /// <summary>
        ///     Верхняя граница
        /// </summary>
        [JsonProperty("to")]
        public virtual decimal To { get; set; }

        [JsonProperty("resume_id")]
        public virtual long ResumeId { get; set; }
    }
}