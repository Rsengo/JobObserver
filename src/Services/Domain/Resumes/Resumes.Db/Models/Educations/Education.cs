using System;
using System.Collections.Generic;
using BuildingBlocks.Database.EntityFramework.Models;
using Resumes.Db.Models.Specializations;

namespace Resumes.Db.Models.Educations
{
    /// <summary>
    ///     Образование
    /// </summary>
    public class Education : RelationalEntity
    {
        /// <summary>
        ///     Уровень образования
        /// </summary>
        public virtual EducationalLevel EducationalLevel { get; set; }

        /// <summary>
        ///     Id Уровня образования
        /// </summary>
        public virtual long EducationalLevelId { get; set; }

        /// <summary>
        ///     Направление подготовки
        /// </summary>
        public virtual string School { get; set; }

        /// <summary>
        ///     Id Факультета
        /// </summary>
        public virtual long FacultyId { get; set; }

        /// <summary>
        ///     Дата поступления
        /// </summary>
        public virtual DateTime AdmissionDate { get; set; }

        /// <summary>
        ///     Дата окончания
        /// </summary>
        public virtual DateTime GraduationDate { get; set; }

        /// <summary>
        ///     Список специализаций
        /// </summary>
        public virtual ICollection<Specialization> Specializations { get; set; }
    }
}