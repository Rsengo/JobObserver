using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.DataTransfer.Models;
using Newtonsoft.Json;
using Resumes.Dto.Models.Geographic;

namespace Resumes.Dto.Models.Applicants
{
    public class DtoApplicant
    {
        [JsonProperty("id")]
        public virtual Guid Id { get; set; }

        /// <summary>
        ///     Фамилия
        /// </summary>
        [JsonProperty("last_name")]
        public virtual string LastName { get; set; }

        /// <summary> 
        ///     Имя
        /// </summary>
        [JsonProperty("first_name")]
        public virtual string FirstName { get; set; }

        /// <summary>
        ///     Отчество
        /// </summary>
        [JsonProperty("middle_name")]
        public virtual string MiddleName { get; set; }

        /// <summary>
        ///     Дата рождения
        /// </summary>
        [JsonProperty("birth_date")]
        public virtual DateTime BirthDate { get; set; }

        /// <summary>
        ///     Пол
        /// </summary>
        [JsonProperty("gender")]
        public virtual DtoGender Gender { get; set; }

        /// <summary>
        ///     Id Пола
        /// </summary>
        [JsonProperty("gender_id")]
        public virtual long? GenderId { get; set; }

        /// <summary>
        ///     Id Города
        /// </summary>
        [JsonProperty("area_id")]
        public virtual long? AreaId { get; set; }

        /// <summary>
        ///     Город
        /// </summary>
        [JsonProperty("area")]
        public virtual DtoArea Area { get; set; }

        /// <summary>
        ///     Полное имя
        /// </summary>
        [JsonProperty("full_name")]
        public virtual string FullName { get; set; }
    }
}
