using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CareerDays.Dto.Models
{
    public class DtoCareerDay
    {
        /// <summary>
        /// Описание
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Id Брендированного шаблона
        /// </summary>
        [JsonProperty("branded_description_id")]
        public long? BrandedDescriptionId { get; set; }

        /// <summary>
        /// Дата начала
        /// </summary>
        [JsonProperty("start_at")]
        public DateTime StartsAt { get; set; }

        /// <summary>
        /// Id Организации
        /// </summary>
        [JsonProperty("employer_id")]
        public long EmployerId { get; set; }

        /// <summary>
        /// Название организации
        /// </summary>
        [JsonProperty("employer_name")]
        public string EmployerName { get; set; }

        /// <summary>
        /// Id Образовательное учреждение 
        /// </summary>
        [JsonProperty("educationa_linstitution_id")]
        public long? EducationalInstitutionId { get; set; }

        /// <summary>
        /// Название образовательного учреждения
        /// </summary>
        [JsonProperty("educationa_linstitution_name")]
        public string EducationalInstitutionName { get; set; }
    }
}
