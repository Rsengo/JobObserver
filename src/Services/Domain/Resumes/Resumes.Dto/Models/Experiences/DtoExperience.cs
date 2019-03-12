using System;
using BuildingBlocks.DataTransfer.Models;
using Newtonsoft.Json;
using Resumes.Dto.Models.Industries;
using Resumes.Dto.Models.Specializations;

namespace Resumes.Dto.Models.Experiences
{
    /// <summary>
    ///     Опыт
    /// </summary>
    public class DtoExperience : DtoEntity
    {
        /// <summary>
        ///     Id Работодателя
        /// </summary>
        [JsonProperty("company_id")]
        public virtual long? CompanyId { get; set; }

        /// <summary>
        ///     Сфера деятельности
        /// </summary>
        [JsonProperty("industry")]
        public virtual DtoIndustry Industry { get; set; }

        /// <summary>
        ///     Id Сферы деятельности
        /// </summary>
        [JsonProperty("industry_id")]
        public virtual long IndustryId { get; set; }

        /// <summary>
        ///     Специализация
        /// </summary>
        [JsonProperty("specialization")]
        public virtual DtoSpecialization Specialization { get; set; }

        /// <summary>
        ///     Id Специализации
        /// </summary>
        [JsonProperty("specialization_id")]
        public virtual long SpecializationId { get; set; }

        /// <summary>
        ///     Должность
        /// </summary>
        [JsonProperty("title")]
        public virtual string Title { get; set; }

        /// <summary>
        ///     Начало  работы
        /// </summary>
        [JsonProperty("started_at")]
        public virtual DateTime StartedAt { get; set; }

        /// <summary>
        ///     Конец работы
        /// </summary>
        [JsonProperty("end_at")]
        public virtual DateTime EndAt { get; set; }

        /// <summary>
        ///     Описание
        /// </summary>
        [JsonProperty("description")]
        public virtual string Description { get; set; }

        [JsonProperty("resume_id")]
        public virtual long ResumeId { get; set; }
    }
}