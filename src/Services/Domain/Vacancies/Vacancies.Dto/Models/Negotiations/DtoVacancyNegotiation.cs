using System;
using BuildingBlocks.DataTransfer.Models;
using BuildingBlocks.EntityFramework.Models;
using Newtonsoft.Json;

namespace Vacancies.Dto.Models.Negotiations
{
    /// <summary>
    ///     Оклик на вакансию
    /// </summary>
    public class DtoVacancyNegotiation : DtoEntity
    {
        /// <summary>
        ///     Id Соискателя, оставившего отзыв
        /// </summary>
        [JsonProperty("applicant_id")]
        public virtual long ApplicantId { get; set; }

        /// <summary>
        ///     Id Вакансии
        /// </summary>
        [JsonProperty("vacancy_id")]
        public virtual long VacancyId { get; set; }

        /// <summary>
        ///     Сообщение
        /// </summary>
        [JsonProperty("message")]
        public virtual string Message { get; set; }

        /// <summary>
        ///     Ответ на отзыв
        /// </summary>
        [JsonProperty("response")]
        public virtual DtoResponse Response { get; set; }

        /// <summary>
        ///     Id Ответа на отзыв
        /// </summary>
        [JsonProperty("response_id")]
        public virtual long? ResponseId { get; set; }

        /// <summary>
        ///     Дата
        /// </summary>
        [JsonProperty("date")]
        public virtual DateTime Date { get; set; }
    }
}