using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.DataTransfer.Models;

namespace Dictionaries.Dto.Models
{
    /// <summary>
    /// Сборник словарей
    /// </summary>
    public class DtoDictionaries
    {
        /// <summary>
        /// Типы водительских прав
        /// </summary>
        [JsonProperty("driving_license_types")]
        public IEnumerable<DtoDictionary> DrivingLicenseTypes { get; set; }

        /// <summary>
        /// Уровень образования
        /// </summary>
        [JsonProperty("education_levels")]
        public IEnumerable<DtoDictionary> EducationalLevels { get; set; }

        /// <summary>
        /// Тип занятости
        /// </summary>
        [JsonProperty("employment")]
        public IEnumerable<DtoDictionary> Employment { get; set; }

        /// <summary>
        /// Уровень языка
        /// </summary>
        [JsonProperty("language_levels")]
        public IEnumerable<DtoDictionary> LanguageLevels { get; set; }

        /// <summary>
        /// Язык
        /// </summary>
        [JsonProperty("languages")]
        public IEnumerable<DtoDictionary> Languages { get; set; }

        /// <summary>
        /// Ответ на отклик
        /// </summary>
        [JsonProperty("responses")]
        public IEnumerable<DtoDictionary> Responses { get; set; }

        /// <summary>
        /// Тип компании
        /// </summary>
        [JsonProperty("employer_types")]
        public IEnumerable<DtoDictionary> EmployerTypes { get; set; }

        /// <summary>
        /// Тип переезда
        /// </summary>
        [JsonProperty("relocation_types")]
        public IEnumerable<DtoDictionary> RelocationTypes { get; set; }

        /// <summary>
        /// Готовность к командировкам
        /// </summary>
        [JsonProperty("business_trip_readiness")]
        public IEnumerable<DtoDictionary> BusinessTripReadiness { get; set; }

        /// <summary>
        /// Время поездки
        /// </summary>
        [JsonProperty("travel_times")]
        public IEnumerable<DtoDictionary> TravelTimes { get; set; }

        /// <summary>
        /// Валюта
        /// </summary>
        [JsonProperty("currency")]
        public IEnumerable<DtoDictionary> Currency { get; set; }

        /// <summary>
        /// Тип расписания
        /// </summary>
        [JsonProperty("schedules")]
        public IEnumerable<DtoDictionary> Schedules { get; set; }

        /// <summary>
        /// Тип сайта
        /// </summary>
        [JsonProperty("site_types")]
        public IEnumerable<DtoDictionary> SiteTypes { get; set; }

        /// <summary>
        /// Стату резюме
        /// </summary>
        [JsonProperty("resume_statuses")]
        public IEnumerable<DtoDictionary> ResumeStatuses { get; set; }

        /// <summary>
        /// Статус вакансии
        /// </summary>
        [JsonProperty("vacancy_statuses")]
        public IEnumerable<DtoDictionary> VacancyStatuses { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        [JsonProperty("genders")]
        public IEnumerable<DtoDictionary> Genders { get; set; }
    }
}
