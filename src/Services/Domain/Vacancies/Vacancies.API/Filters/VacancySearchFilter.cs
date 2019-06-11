using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacancies.Db.Dto.Models.Geographic;
using Vacancies.Db.Dto.Models.Industries;
using Vacancies.Db.Dto.Models.Languages;
using Vacancies.Db.Dto.Models.Salaries;
using Vacancies.Db.Models.Geographic;

namespace Vacancies.API.Filters
{
    public class VacancySearchFilter : PaginationFilter
    {
        /// <summary>
        ///     Навыки
        /// </summary>
        [JsonProperty("key_skill_ids")]
        public virtual ICollection<long> KeySkillIds { get; set; }

        /// <summary>
        ///     Языки
        /// </summary>
        [JsonProperty("languages")]
        public virtual ICollection<DtoLanguageSkill> Languages { get; set; }

        /// <summary>
        ///     Расписание
        /// </summary>
        [JsonProperty("schedule_ids")]
        public virtual ICollection<long> ScheduleIds { get; set; }

        /// <summary>
        ///     Подходит для инвалидов
        /// </summary>
        [JsonProperty("accept_handicapes")]
        public virtual bool? AcceptHandicapped { get; set; }

        /// <summary>
        ///     Адрес.
        /// </summary>
        [JsonProperty("area_ids")]
        public virtual ICollection<long> AreaIds { get; set; }

        /// <summary>
        ///     Тип занятости
        /// </summary>
        [JsonProperty("employment_ids")]
        public virtual ICollection<long> EmploymentIds { get; set; }

        /// <summary>
        ///     Зарплата
        /// </summary>
        [JsonProperty("salary")]
        public virtual ICollection<DtoSalary> Salary { get; set; }

        /// <summary>
        ///     Должность
        /// </summary>
        [JsonProperty("title")]
        public virtual string Title { get; set; }

        /// <summary>
        ///     Дата создания
        /// </summary>
        [JsonProperty("published_at_min")]
        public virtual DateTime PublishedAtMin { get; set; }

        /// <summary>
        ///     Дата создания
        /// </summary>
        [JsonProperty("published_at_max")]
        public virtual DateTime PublishedAtMax { get; set; }

        /// <summary>
        ///     Id Работодателя
        /// </summary>
        [JsonProperty("employer_ids")]
        public virtual ICollection<long> EmployerIds { get; set; }

        /// <summary>
        ///     Водительские права
        /// </summary>
        [JsonProperty("driver_license_type_ids")]
        public virtual ICollection<long> DrivingLicenseTypeIds { get; set; }

        /// <summary>
        ///     Требуетс ли автомобиль
        /// </summary>
        [JsonProperty("required_vehicle")]
        public virtual bool? RequiredVehicle { get; set; }

        [JsonProperty("industry_ids")]
        public virtual ICollection<long> IndustryIds { get; set; }

        [JsonProperty("specialization_ids")]
        public virtual ICollection<long> SpecializationIds { get; set; }
    }
}
