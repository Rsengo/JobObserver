using System;
using BuildingBlocks.DataTransfer.Models;
using Newtonsoft.Json;

namespace Resumes.Dto.Models.Negotiations
{
    /// <summary>
    ///     Отклик на резюме
    /// </summary>
    public class DtoResumeNegotiation : DtoEntity
    {
        /// <summary>
        ///     Id Компании
        /// </summary>
        [JsonProperty("company_id")]
        public virtual long CompanyId { get; set; }

        /// <summary>
        ///     Id Резюме
        /// </summary>
        [JsonProperty("resume_id")]
        public virtual long ResumeId { get; set; }

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