using System;
using System.Collections.Generic;
using BuildingBlocks.DataTransfer.Models;
using Newtonsoft.Json;
using Resumes.Db.Dto.Models.Applicants;
using Resumes.Db.Dto.Models.Certificates;
using Resumes.Db.Dto.Models.Driving;
using Resumes.Db.Dto.Models.Educations;
using Resumes.Db.Dto.Models.Employments;
using Resumes.Db.Dto.Models.Experiences;
using Resumes.Db.Dto.Models.Languages;
using Resumes.Db.Dto.Models.Salaries;
using Resumes.Db.Dto.Models.Schedules;
using Resumes.Db.Dto.Models.Skills;
using Resumes.Db.Dto.Models.Specializations;
using Resumes.Db.Dto.Models.Statuses;
using Resumes.Db.Dto.Models.Travel;
using Resumes.Db.Dto.Models.Travel.Relocation;
using Resumes.Db.Dto.Models.Geographic;
using Resumes.Db.Dto.Models.Geographic.Metro;

namespace Resumes.Db.Dto.Models
{
    /// <summary>
    ///     Резюме
    /// </summary>
    public class DtoResume : DtoEntity
    {
        /// <summary>
        ///     Id Соискателя
        /// </summary>
        [JsonProperty("applicant_id")]
        public virtual Guid ApplicantId { get; set; }

        [JsonProperty("applicant")]
        public virtual DtoApplicant Applicant { get; set; }

        /// <summary>
        /// Город.
        /// </summary>
        [JsonProperty("area")]
        public virtual DtoArea Area { get; set; }

        /// <summary>
        ///     Id Города
        /// </summary>
        [JsonProperty("area_id")]
        public virtual long? AreaId { get; set; }

        /// <summary>
        ///     Id Метро
        /// </summary>
        [JsonProperty("metro_station_id")]
        public virtual long? MetroStationId { get; set; }

        [JsonProperty("metro_station")]
        public virtual DtoStation MetroStation { get; set; }

        /// <summary>
        ///     Возможность переезда
        /// </summary>
        [JsonProperty("relocation_possibility")]
        public virtual ICollection<DtoRelocationPossibility> RelocationPossibility { get; set; }

        /// <summary>
        ///     Готовность к командировкам
        /// </summary>
        [JsonProperty("business_trip_readiness")]
        public virtual DtoBusinessTripReadiness BusinessTripReadiness { get; set; }

        /// <summary>
        ///     Id Готовности к командировкам
        /// </summary>
        [JsonProperty("business_trip_readiness_id")]
        public virtual long? BusinessTripReadinessId { get; set; }

        /// <summary>
        ///     Должность
        /// </summary>
        [JsonProperty("title")]
        public virtual string Title { get; set; }

        /// <summary>
        ///     Фото
        /// </summary>
        [JsonProperty("photo_url")]
        public virtual string PhotoUrl { get; set; }

        /// <summary>
        ///     Образование
        /// </summary>
        [JsonProperty("education")]
        public virtual ICollection<DtoEducation> Education { get; set; }

        /// <summary>
        ///     Языки
        /// </summary>
        [JsonProperty("languages")]
        public virtual ICollection<DtoLanguageSkill> Languages { get; set; }

        /// <summary>
        ///     Специализации
        /// </summary>
        [JsonProperty("specializations")]
        public virtual ICollection<DtoSpecialization> Specializations { get; set; }

        /// <summary>
        ///     Желаемая заработная плата
        /// </summary>
        [JsonProperty("salary")]
        public virtual DtoSalary Salary { get; set; }

        /// <summary>
        ///     Id желаемой заработной платы
        /// </summary>
        [JsonProperty("salary_id")]
        public virtual long? SalaryId { get; set; }

        /// <summary>
        ///     Тип занятости
        /// </summary>
        [JsonProperty("employments")]
        public virtual ICollection<DtoEmployment> Employments { get; set; }

        /// <summary>
        ///     Тип расписания
        /// </summary>
        [JsonProperty("schedules")]
        public virtual ICollection<DtoSchedule> Schedules { get; set; }

        /// <summary>
        ///     Опыт
        /// </summary>
        [JsonProperty("experience")]
        public virtual ICollection<DtoExperience> Experience { get; set; }

        /// <summary>
        ///     Навыки
        /// </summary>
        [JsonProperty("skills")]
        public virtual ICollection<DtoSkill> Skills { get; set; }

        /// <summary>
        ///     Гражданства
        /// </summary>
        [JsonProperty("citizenship")]
        public virtual ICollection<DtoArea> Citizenship { get; set; }

        /// <summary>
        ///     Разрешение на работу
        /// </summary>
        [JsonProperty("work_ticket")]
        public virtual ICollection<DtoArea> WorkTicket { get; set; }

        /// <summary>
        ///     Время поездки до работы
        /// </summary>
        [JsonProperty("travel_time")]
        public virtual DtoTravelTime TravelTime { get; set; }

        /// <summary>
        ///     Id Времени поездки до работы
        /// </summary>
        [JsonProperty("travel_time_id")]
        public virtual long? TravelTimeId { get; set; }

        /// <summary>
        ///     Язык резюме
        /// </summary>
        [JsonProperty("resume_locale")]
        public virtual DtoLanguage ResumeLocale { get; set; }

        /// <summary>
        ///     Id Языка резюме
        /// </summary>
        [JsonProperty("resume_locale_id")]
        public virtual long? ResumeLocaleId { get; set; }

        /// <summary>
        ///     Сертификаты
        /// </summary>
        [JsonProperty("certificates")]
        public virtual ICollection<DtoCertificate> Certificates { get; set; }

        /// <summary>
        ///     Дата создания резюме
        /// </summary>
        [JsonProperty("created_at")]
        public virtual DateTime CreatedAt { get; set; }

        /// <summary>
        ///     Дата последнего обновления резюме
        /// </summary>
        [JsonProperty("updated_at")]
        public virtual DateTime UpdatedAt { get; set; }

        /// <summary>
        ///     Имеется транспортное средство
        /// </summary>
        [JsonProperty("has_vehicle")]
        public virtual bool HasVehicle { get; set; }

        /// <summary>
        ///     Категории прав
        /// </summary>
        [JsonProperty("driver_license_types")]
        public virtual ICollection<DtoDrivingLicenseType> DrivingLicenseTypes { get; set; }

        /// <summary>
        ///     Дополнительная информаци
        /// </summary>
        [JsonProperty("additional_info")]
        public virtual string AdditionalInfo { get; set; }

        /// <summary>
        ///     Премиум
        /// </summary>
        [JsonProperty("is_premium")]
        public virtual bool IsPremium { get; set; }

        /// <summary>
        ///     Статус резюме
        /// </summary>
        [JsonProperty("resume_status")]
        public virtual DtoResumeStatus ResumeStatus { get; set; }

        /// <summary>
        ///     Id Статуса резюме
        /// </summary>
        [JsonProperty("resume_status_id")]
        public virtual long? ResumeStatusId { get; set; }
    }
}