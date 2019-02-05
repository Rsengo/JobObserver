using System;
using System.Collections.Generic;
using System.Linq;
using BuildingBlocks.Database.EntityFramework.Models;
using Resumes.Db.Models.Driving;
using Resumes.Db.Models.Educations;
using Resumes.Db.Models.Employments;
using Resumes.Db.Models.Experiences;
using Resumes.Db.Models.Languages;
using Resumes.Db.Models.Recommendations;
using Resumes.Db.Models.Salaries;
using Resumes.Db.Models.Schedules;
using Resumes.Db.Models.Skills;
using Resumes.Db.Models.Specializations;
using Resumes.Db.Models.Statuses;
using Resumes.Db.Models.Travel;
using Resumes.Db.Models.Travel.Relocation;

namespace Resumes.Db.Models
{
    /// <summary>
    ///     Резюме
    /// </summary>
    public class Resume : RelationalEntity
    {
        /// <summary>
        ///     Id Соискателя
        /// </summary>
        public virtual long ApplicantId { get; set; }

        /// <summary>
        ///     Id Города
        /// </summary>
        public virtual long? AreaId { get; set; }

        /// <summary>
        ///     Id Метро
        /// </summary>
        public virtual long? MetroStationId { get; set; }

        /// <summary>
        ///     Возможность переезда
        /// </summary>
        public virtual ICollection<RelocationPossibility> RelocationPossibility { get; set; }

        /// <summary>
        ///     Готовность к командировкам
        /// </summary>
        public virtual BusinessTripReadiness BusinessTripReadiness { get; set; }

        /// <summary>
        ///     Id Готовности к командировкам
        /// </summary>
        public virtual long? BusinessTripReadinessId { get; set; }

        /// <summary>
        ///     Должность
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        ///     Фото
        /// </summary>
        public virtual Photo Photo { get; set; }

        /// <summary>
        ///     Id Фото
        /// </summary>
        public virtual long? PhotoId { get; set; }

        /// <summary>
        ///     Портфолио
        /// </summary>
        public virtual ICollection<Portfolio> Portfolio { get; set; }

        /// <summary>
        ///     Образование
        /// </summary>
        public virtual ICollection<Education> Education { get; set; }

        /// <summary>
        ///     Языки
        /// </summary>
        public virtual ICollection<LanguageSkill> Languages { get; set; }


        /// <summary>
        ///     Специализации
        /// </summary>
        public virtual ICollection<Specialization> Specializations { get; set; }

        /// <summary>
        ///     Желаемая заработная плата
        /// </summary>
        public virtual Salary Salary { get; set; }

        /// <summary>
        ///     Id желаемой заработной платы
        /// </summary>
        public virtual long? SalaryId { get; set; }

        /// <summary>
        ///     Тип занятости
        /// </summary>
        public virtual ICollection<Employment> Employments { get; set; }

        /// <summary>
        ///     Тип расписания
        /// </summary>
        public virtual ICollection<Schedule> Schedules { get; set; }

        /// <summary>
        ///     Опыт
        /// </summary>
        public virtual ICollection<Experience> Experience { get; set; }

        /// <summary>
        ///     Навыки
        /// </summary>
        public virtual ICollection<Skill> Skills { get; set; }

        /// <summary>
        ///     Гражданства
        /// </summary>
        public virtual ICollection<Area> Citizenship =>
            CitizenshipLinks
                .Select(x => x.Citizenship)
                .ToList();

        /// <summary>
        ///     Разрешение на работу
        /// </summary>
        public virtual ICollection<Area> WorkTicket =>
            WorkTicketLinks
                .Select(x => x.WorkTicket)
                .ToList();

        /// <summary>
        ///     Время поездки до работы
        /// </summary>
        public virtual TravelTime TravelTime { get; set; }

        /// <summary>
        ///     Id Времени поездки до работы
        /// </summary>
        public virtual long? TravelTimeId { get; set; }

        /// <summary>
        ///     Рекомендации работодателей
        /// </summary>
        public virtual ICollection<EmployerRecommendation> EmployerRecommendations { get; set; }

        /// <summary>
        ///     Рекомендации ОУ
        /// </summary>
        public virtual ICollection<EducationalInstitutionRecommendation> EducationalInstitutionRecommendations
        {
            get;
            set;
        }

        /// <summary>
        ///     Язык резюме
        /// </summary>
        public virtual Language ResumeLocale { get; set; }

        /// <summary>
        ///     Id Языка резюме
        /// </summary>
        public virtual long? ResumeLocaleId { get; set; }

        /// <summary>
        ///     Сертификаты
        /// </summary>
        public virtual ICollection<Certificate> Certificates { get; set; }

        /// <summary>
        ///     Дата создания резюме
        /// </summary>
        public virtual DateTime CreatedAt { get; set; }

        /// <summary>
        ///     Дата последнего обновления резюме
        /// </summary>
        public virtual DateTime UpdatedAt { get; set; }

        /// <summary>
        ///     Имеется транспортное ссредство
        /// </summary>
        public virtual bool HasVehicle { get; set; }

        /// <summary>
        ///     Категории прав
        /// </summary>
        public virtual ICollection<DriverLicenseType> DriverLicenseTypes { get; set; }

        /// <summary>
        ///     Дополнительная информаци
        /// </summary>
        public virtual string AdditionalInfo { get; set; }

        /// <summary>
        ///     Премиум
        /// </summary>
        public virtual bool IsPremium { get; set; }

        /// <summary>
        ///     Статус резюме
        /// </summary>
        public virtual ResumeStatus ResumeStatus { get; set; }

        /// <summary>
        ///     Id Статуса резюме
        /// </summary>
        public virtual long? ResumeStatusId { get; set; }
    }
}