using System;
using System.Collections.Generic;
using System.Text;
using CareerDays.Db.Dto.Models.Geographic;
using Newtonsoft.Json;

namespace CareerDays.Db.Dto.Models
{
    public class DtoCareerDay
    {
        /// <summary>
        /// Описание
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Брендированный шаблон
        /// </summary>
        [JsonProperty("branded_description")]
        public DtoBrandedTemplate BrandedDescription { get; set; }

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
        ///     Организация.
        /// </summary>
        [JsonProperty("employer")]
        public DtoEmployer Employer { get; set; }

        /// <summary>
        /// Id Образовательное учреждение 
        /// </summary>
        [JsonProperty("educational_institution_id")]
        public long? EducationalInstitutionId { get; set; }

        /// <summary>
        /// Название образовательного учреждения
        /// </summary>
        [JsonProperty("educational_institution")]
        public DtoEducationalInstitution EducationalInstitution { get; set; }

        /// <summary>
        ///     Адрес.
        /// </summary>
        [JsonProperty("address")]
        public DtoAddress Address { get; set; }

        /// <summary>
        ///     Id адреса.
        /// </summary>
        [JsonProperty("address_id")]
        public long AddressId { get; set; }
    }
}
