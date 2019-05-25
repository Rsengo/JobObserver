using System;
using System.Collections.Generic;
using BuildingBlocks.DataTransfer.Models;
using BuildingBlocks.EntityFramework.Models;
using Newtonsoft.Json;
using Vacancies.Db.Models.Geographic;
using Vacancies.Db.Dto.Models.Driving;
using Vacancies.Db.Dto.Models.BrandedTemplates;
using Vacancies.Db.Dto.Models.Employers;
using Vacancies.Db.Dto.Models.Employments;
using Vacancies.Db.Dto.Models.Geographic;
using Vacancies.Db.Dto.Models.Industries;
using Vacancies.Db.Dto.Models.Languages;
using Vacancies.Db.Dto.Models.Negotiations;
using Vacancies.Db.Dto.Models.Salaries;
using Vacancies.Db.Dto.Models.Schedules;
using Vacancies.Db.Dto.Models.Skills;
using Vacancies.Db.Dto.Models.Specializations;
using Vacancies.Db.Dto.Models.Statuses;
using Vacancies.Db.Dto.Models.Tests;

namespace Vacancies.Db.Dto.Models
{
    public class DtoVacancy : DtoEntity
    {
        /// <summary>
        ///     Описание
        /// </summary>
        [JsonProperty("description")]
        public virtual string Description { get; set; }

        /// <summary>
        ///     Id Брендированного описания
        /// </summary>
        [JsonProperty("branded_description")]
        public virtual DtoBrandedTemplate BrandedDescription { get; set; }

        /// <summary>
        ///     Навыки
        /// </summary>
        [JsonProperty("key_skills")]
        public virtual ICollection<DtoSkill> KeySkills { get; set; }

        /// <summary>
        ///     Языки
        /// </summary>
        [JsonProperty("languages")]
        public virtual ICollection<DtoLanguageSkill> Languages { get; set; }

        /// <summary>
        ///     Расписание
        /// </summary>
        [JsonProperty("schedule")]
        public virtual DtoSchedule Schedule { get; set; }

        /// <summary>
        ///     Id Расписания
        /// </summary>
        [JsonProperty("schedule_id")]
        public virtual long? ScheduleId { get; set; }

        /// <summary>
        ///     Подходит для инвалидов
        /// </summary>
        [JsonProperty("accept_handicapes")]
        public virtual bool AcceptHandicapped { get; set; }

        /// <summary>
        ///     Id Адреса
        /// </summary>
        [JsonProperty("address_id")]
        public virtual long? AddressId { get; set; }

        /// <summary>
        ///     Адрес.
        /// </summary>
        [JsonProperty("address")]
        public virtual Address Address { get; set; }

        /// <summary>
        ///     Id Отделения
        /// </summary>
        [JsonProperty("department_id")]
        public virtual long? DepartmentId { get; set; }

        [JsonProperty("department")]
        public virtual DtoDepartment Department { get; set; }

        /// <summary>
        ///     Тип занятости
        /// </summary>
        [JsonProperty("employment")]
        public virtual DtoEmployment Employment { get; set; }

        /// <summary>
        ///     Id Типа занятости
        /// </summary>
        [JsonProperty("employment_id")]
        public virtual long? EmploymentId { get; set; }

        /// <summary>
        ///     Зарплата
        /// </summary>
        [JsonProperty("salary")]
        public virtual DtoSalary Salary { get; set; }

        /// <summary>
        ///     Id Зарплаты
        /// </summary>
        [JsonProperty("salary_id")]
        public virtual long? SalaryId { get; set; }

        /// <summary>
        ///     Должность
        /// </summary>
        [JsonProperty("title")]
        public virtual string Title { get; set; }

        /// <summary>
        ///     Дата создания
        /// </summary>
        [JsonProperty("published_at")]
        public virtual DateTime PublishedAt { get; set; }

        /// <summary>
        ///     Id Работодателя
        /// </summary>
        [JsonProperty("employer_id")]
        public virtual long EmployerId { get; set; }

        [JsonProperty("employer")]
        public virtual DtoEmployer Employer { get; set; }

        /// <summary>
        ///     Обязательно ли заполнять письмо при отклике на вакансию
        /// </summary>
        [JsonProperty("response_letter_required")]
        public virtual bool ResponseLetterRequired { get; set; }

        /// <summary>
        ///     Тесты
        /// </summary>
        [JsonProperty("tests")]
        public virtual ICollection<DtoVacancyTest> Tests { get; set; }

        /// <summary>
        ///     Включена ли возможность соискателю писать сообщения работодателю, после приглашения/отклика на вакансию
        /// </summary>
        [JsonProperty("allow_messages")]
        public virtual bool AllowMessages { get; set; }

        /// <summary>
        ///     Водительские права
        /// </summary>
        [JsonProperty("driver_license_types")]
        public virtual ICollection<DtoDrivingLicenseType> DrivingLicenseTypes { get; set; }

        /// <summary>
        ///     Требуетс ли автомобиль
        /// </summary>
        [JsonProperty("required_vehicle")]
        public virtual bool RequiredVehicle { get; set; }

        /// <summary>
        ///     Премиум
        /// </summary>
        [JsonProperty("is_premium")]
        public virtual bool IsPremium { get; set; }

        /// <summary>
        ///     дата и время окончания публикации вакансии
        /// </summary>
        [JsonProperty("expires_at")]
        public virtual DateTime ExpiresAt { get; set; }

        /// <summary>
        ///     уведомлять ли менеджера о новых откликах
        /// </summary>
        [JsonProperty("response_notification")]
        public virtual bool ResponseNotification { get; set; }

        /// <summary>
        ///     Id Ответственного менеджера
        /// </summary>
        [JsonProperty("manager_id")]
        public virtual Guid? ManagerId { get; set; }

        /// <summary>
        ///     Статус вакансии
        /// </summary>
        [JsonProperty("vacancy_status")]
        public virtual DtoVacancyStatus VacancyStatus { get; set; }

        /// <summary>
        ///     Id Статуса вакансии
        /// </summary>
        [JsonProperty("vacancy_status_id")]
        public virtual long? VacancyStatusId { get; set; }

        [JsonProperty("industry")]
        public virtual DtoIndustry Industry { get; set; }

        [JsonProperty("industry_id")]
        public virtual long IndustryId { get; set; }

        [JsonProperty("specializations")]
        public virtual ICollection<DtoSpecialization> Specializations { get; set; }
    }
}