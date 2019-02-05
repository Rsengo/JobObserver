using System;
using System.Collections.Generic;
using BuildingBlocks.Database.EntityFramework.Models;
using Vacancies.Db.Models.Driving;
using Vacancies.Db.Models.Employments;
using Vacancies.Db.Models.Languages;
using Vacancies.Db.Models.Salaries;
using Vacancies.Db.Models.Schedules;
using Vacancies.Db.Models.Skills;
using Vacancies.Db.Models.Statuses;
using Vacancies.Db.Models.Tests;

namespace Vacancies.Db.Models
{
    public class Vacancy : RelationalEntity
    {
        /// <summary>
        ///     Описание
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        ///     Id Брендированного описания
        /// </summary>
        public virtual long? BrandedDescriptionId { get; set; }

        /// <summary>
        ///     Навыки
        /// </summary>
        public virtual ICollection<Skill> KeySkills { get; set; }

        /// <summary>
        ///     Языки
        /// </summary>
        public virtual ICollection<LanguageSkill> Languages { get; set; }

        /// <summary>
        ///     Расписание
        /// </summary>
        public virtual Schedule Schedule { get; set; }

        /// <summary>
        ///     Id Расписания
        /// </summary>
        public virtual long? ScheduleId { get; set; }

        /// <summary>
        ///     Подходит для инвалидов
        /// </summary>
        public virtual bool AcceptHandicapped { get; set; }

        /// <summary>
        ///     Id Адресса
        /// </summary>
        public virtual long? AddressId { get; set; }

        /// <summary>
        ///     Id Отделения
        /// </summary>
        public virtual long? DepartmentId { get; set; }

        /// <summary>
        ///     Тип занятости
        /// </summary>
        public virtual Employment Employment { get; set; }

        /// <summary>
        ///     Id Типа занятости
        /// </summary>
        public virtual long? EmploymentId { get; set; }

        /// <summary>
        ///     Зарплата
        /// </summary>
        public virtual Salary Salary { get; set; }

        /// <summary>
        ///     Id Зарплаты
        /// </summary>
        public virtual long? SalaryId { get; set; }

        /// <summary>
        ///     Должность
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        ///     Дата создания
        /// </summary>
        public virtual DateTime PublishedAt { get; set; }

        /// <summary>
        ///     Id Работодателя
        /// </summary>
        public virtual long EmployerId { get; set; }

        /// <summary>
        ///     Обязательно ли заполнять письмо при отклике на вакансию
        /// </summary>
        public virtual bool ResponseLetterRequired { get; set; }

        /// <summary>
        ///     Тесты
        /// </summary>
        public virtual ICollection<Test> Tests { get; set; }

        /// <summary>
        ///     Включена ли возможность соискателю писать сообщения работодателю, после приглашения/отклика на вакансию
        /// </summary>
        public virtual bool AllowMessages { get; set; }

        /// <summary>
        ///     Водительские права
        /// </summary>
        public virtual ICollection<DriverLicenseType> DriverLicenseTypes { get; set; }

        /// <summary>
        ///     Требуетс ли автомобиль
        /// </summary>
        public virtual bool RequiredVehicle { get; set; }

        /// <summary>
        ///     Разрешен ли отклик на вакансию неполным резюме
        /// </summary>
        public virtual bool AcceptIncompleteResumes { get; set; }

        /// <summary>
        ///     Премиум
        /// </summary>
        public virtual bool IsPremium { get; set; }

        /// <summary>
        ///     дата и время окончания публикации вакансии
        /// </summary>
        public virtual DateTime ExpiresAt { get; set; }

        /// <summary>
        ///     уведомлять ли менеджера о новых откликах
        /// </summary>
        public virtual bool ResponseNotification { get; set; }

        /// <summary>
        ///     Id Ответственного менеджера
        /// </summary>
        public virtual long? ManagerId { get; set; }

        /// <summary>
        ///     Статус вакансии
        /// </summary>
        public virtual VacancyStatus VacancyStatus { get; set; }

        /// <summary>
        ///     Id Статуса вакансии
        /// </summary>
        public virtual long? VacancyStatusId { get; set; }
    }
}