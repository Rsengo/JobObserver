using Newtonsoft.Json;
using Resumes.Db.Dto.Models.Languages;
using Resumes.Db.Dto.Models.Salaries;
using Resumes.Db.Dto.Models.Travel.Relocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resumes.API.Filters
{
    public class ResumeSearchFilter: PaginationFilter
    {
        /// <summary>
        ///     Id Соискателя
        /// </summary>
        [JsonProperty("applicant_id")]
        public virtual Guid? ApplicantId { get; set; }

        /// <summary>
        /// Город.
        /// </summary>
        [JsonProperty("area_ids")]
        public virtual ICollection<long> AreaIds { get; set; }

        /// <summary>
        ///     Id Метро
        /// </summary>
        [JsonProperty("metro_station_ids")]
        public virtual ICollection<long> MetroStationIds { get; set; }


        /// <summary>
        ///     Возможность переезда
        /// </summary>
        [JsonProperty("relocation_possibility")]
        public virtual ICollection<DtoRelocationPossibility> RelocationPossibility { get; set; }


        /// <summary>
        ///     Id Готовности к командировкам
        /// </summary>
        [JsonProperty("business_trip_readiness_ids")]
        public virtual ICollection<long> BusinessTripReadinessIds { get; set; }

        /// <summary>
        ///     Должность
        /// </summary>
        [JsonProperty("title")]
        public virtual string Title { get; set; }

        /// <summary>
        ///     Языки
        /// </summary>
        [JsonProperty("languages")]
        public virtual ICollection<DtoLanguageSkill> Languages { get; set; }

        /// <summary>
        ///     Специализации
        /// </summary>
        [JsonProperty("specialization_ids")]
        public virtual ICollection<long> SpecializationIds { get; set; }

        /// <summary>
        ///     Желаемая заработная плата
        /// </summary>
        [JsonProperty("salaries")]
        public virtual ICollection<DtoSalary> Salary { get; set; }

        /// <summary>
        ///     Тип занятости
        /// </summary>
        [JsonProperty("employment_ids")]
        public virtual ICollection<long> EmploymentIds { get; set; }

        /// <summary>
        ///     Тип расписания
        /// </summary>
        [JsonProperty("schedule_ids")]
        public virtual ICollection<long> ScheduleIds { get; set; }

        /// <summary>
        ///     Навыки
        /// </summary>
        [JsonProperty("skill_ids")]
        public virtual ICollection<long> SkillIds { get; set; }

        /// <summary>
        ///     Гражданства
        /// </summary>
        [JsonProperty("citizenship_area_ids")]
        public virtual ICollection<long> CitizenshipIds { get; set; }

        /// <summary>
        ///     Разрешение на работу
        /// </summary>
        [JsonProperty("work_ticket_area_ids")]
        public virtual ICollection<long> WorkTicketIds { get; set; }

        /// <summary>
        ///     Время поездки до работы
        /// </summary>
        [JsonProperty("travel_time_ids")]
        public virtual ICollection<long> TravelTimeIds { get; set; }

        /// <summary>
        ///     Язык резюме
        /// </summary>
        [JsonProperty("resume_locale_ids")]
        public virtual ICollection<long> ResumeLocaleIds { get; set; }

        /// <summary>
        ///     Дата последнего обновления резюме
        /// </summary>
        [JsonProperty("updated_at_min")]
        public virtual DateTime UpdatedAtMin { get; set; }

        /// <summary>
        ///     Дата последнего обновления резюме
        /// </summary>
        [JsonProperty("updated_at_max")]
        public virtual DateTime UpdatedAtMax { get; set; }

        /// <summary>
        ///     Имеется транспортное средство
        /// </summary>
        [JsonProperty("has_vehicle")]
        public virtual bool? HasVehicle { get; set; }

        /// <summary>
        ///     Категории прав
        /// </summary>
        [JsonProperty("driver_license_type_ids")]
        public virtual ICollection<long> DrivingLicenseTypeIds { get; set; }
    }
}
