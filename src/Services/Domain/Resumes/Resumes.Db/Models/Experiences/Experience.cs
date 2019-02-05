using System;
using BuildingBlocks.Database.EntityFramework.Models;
using Resumes.Db.Models.Industries;
using Resumes.Db.Models.Specializations;

namespace Resumes.Db.Models.Experiences
{
    /// <summary>
    ///     Опыт
    /// </summary>
    public class Experience : RelationalEntity
    {
        /// <summary>
        ///     Id Работодателя
        /// </summary>
        public virtual long? CompanyId { get; set; }

        /// <summary>
        ///     Сфера деятельности
        /// </summary>
        public virtual Industry Industry { get; set; }

        /// <summary>
        ///     Id Сферы деятельности
        /// </summary>
        public virtual long IndustryId { get; set; }

        /// <summary>
        ///     Специализация
        /// </summary>
        public virtual Specialization Specialization { get; set; }

        /// <summary>
        ///     Id Специализации
        /// </summary>
        public virtual long SpecializationId { get; set; }

        /// <summary>
        ///     Должность
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        ///     Начало  работы
        /// </summary>
        public virtual DateTime StartedAt { get; set; }

        /// <summary>
        ///     Конец работы
        /// </summary>
        public virtual DateTime EndAt { get; set; }

        /// <summary>
        ///     Описание
        /// </summary>
        public virtual string Description { get; set; }
    }
}