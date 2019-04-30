using System;
using System.ComponentModel.DataAnnotations;
using Login.Db.Dto.Models.Attributes;
using Login.Db.Dto.Models.Contacts;
using Newtonsoft.Json;

namespace Login.API.ViewModels
{
    public class RegistrationViewModel
    {
        [Required]
        [JsonProperty("password")]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        [JsonProperty("confirm_password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [JsonProperty("return_url")]
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     Фамилия
        /// </summary>
        [JsonProperty("last_name")]
        public virtual string LastName { get; set; }

        /// <summary>
        ///     Имя
        /// </summary>
        [Required]
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
        [Required]
        [JsonProperty("birth_date")]
        public virtual DateTime BirthDate { get; set; }

        /// <summary>
        ///     Контакты
        /// </summary>
        [JsonProperty("contacts")]
        public virtual DtoContact Contacts { get; set; }

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
        ///     Email.
        /// </summary>
        [Required]
        [EmailAddress]
        [JsonProperty("email")]
        public virtual string Email { get; set; }

        /// <summary>
        ///     Должность
        /// </summary>
        [JsonProperty("position")]
        public virtual string Position { get; set; }

        /// <summary>
        ///     Id Организации
        /// </summary>
        [JsonProperty("organization_id")]
        public virtual long? OrganizationId { get; set; }
    }
}
