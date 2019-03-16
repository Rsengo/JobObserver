using System;
using System.Collections.Generic;
using BuildingBlocks.EntityFramework.Models;
using Resumes.Db.Models.Applicants;
using Resumes.Db.Models.Certificates;
using Resumes.Db.Models.Driving;
using Resumes.Db.Models.Educations;
using Resumes.Db.Models.Employments;
using Resumes.Db.Models.Experiences;
using Resumes.Db.Models.Languages;
using Resumes.Db.Models.Salaries;
using Resumes.Db.Models.Schedules;
using Resumes.Db.Models.Skills;
using Resumes.Db.Models.Specializations;
using Resumes.Db.Models.Statuses;
using Resumes.Db.Models.Travel;
using Resumes.Db.Models.Travel.Relocation;
using Resumes.Db.Models.Geographic;
using Resumes.Db.Models.Geographic.Metro;
using Resumes.Db.Models.Negotiations;
using Resumes.Db.Models.ResumeAreas;

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

        public virtual Applicant Applicant { get; set; }

        /// <summary>
        /// Город.
        /// </summary>
        public virtual Area Area { get; set; }

        /// <summary>
        ///     Id Города
        /// </summary>
        public virtual long? AreaId { get; set; }

        /// <summary>
        ///     Id Метро
        /// </summary>
        public virtual long? MetroStationId { get; set; }

        public virtual Station MetroStation { get; set; }

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
        public virtual string PhotoUrl { get; set; }

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
        public virtual ICollection<ResumeSpecialization> Specializations { get; set; }

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
        public virtual ICollection<ResumeEmployment> Employments { get; set; }

        /// <summary>
        ///     Тип расписания
        /// </summary>
        public virtual ICollection<ResumeSchedule> Schedules { get; set; }

        /// <summary>
        ///     Опыт
        /// </summary>
        public virtual ICollection<Experience> Experience { get; set; }

        /// <summary>
        ///     Навыки
        /// </summary>
        public virtual ICollection<ResumeSkill> Skills { get; set; }

        /// <summary>
        ///     Гражданства
        /// </summary>
        public virtual ICollection<Citizenship> Citizenship { get; set; }

        /// <summary>
        ///     Разрешение на работу
        /// </summary>
        public virtual ICollection<WorkTicket> WorkTicket { get; set; }

        /// <summary>
        ///     Время поездки до работы
        /// </summary>
        public virtual TravelTime TravelTime { get; set; }

        /// <summary>
        ///     Id Времени поездки до работы
        /// </summary>
        public virtual long? TravelTimeId { get; set; }

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
        ///     Имеется транспортное средство
        /// </summary>
        public virtual bool HasVehicle { get; set; }

        /// <summary>
        ///     Категории прав
        /// </summary>
        public virtual ICollection<ResumeDrivingLicenseType> DrivingLicenseTypes { get; set; }

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

        public virtual ICollection<ResumeNegotiation> Negotiations { get; set; }
    }
}