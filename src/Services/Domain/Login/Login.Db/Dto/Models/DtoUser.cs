using System;
using Login.Db.Dto.Models.Contacts;
using Login.Db.Dto.Models.Geographic;
using Login.Db.Dto.Models.Genders;
using Login.Db.Dto.Models.Attributes;
using Newtonsoft.Json;

namespace Login.Db.Dto.Models
{
    /// <summary>
    ///     Абстрактный пользователь
    /// </summary>
    public class DtoUser
    {
        [JsonProperty("id")]
        public virtual string Id { get; set; }

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
        [JsonProperty("middleName")]
        public virtual string MiddleName { get; set; }

        /// <summary>
        ///     Дата рождения
        /// </summary>
        [JsonProperty("birth_date")]
        public virtual DateTime BirthDate { get; set; }

        /// <summary>
        ///     Контакты
        /// </summary>
        [JsonProperty("contacts")]
        public virtual DtoContact Contacts { get; set; }

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

        /// <summary>
        ///     Email.
        /// </summary>
        [JsonProperty("email")]
        public virtual string Email { get; set; }

        [JsonProperty("educational_institution_manager_attributes")]
        public virtual DtoEducationalInstitutionManagerAttributes EducationalInstitutionManagerAttributes { get; set; }

        [JsonProperty("employer_manager_attributes")]
        public virtual DtoEmployerManagerAttributes EmployerManagerAttributes { get; set; }
    }
}