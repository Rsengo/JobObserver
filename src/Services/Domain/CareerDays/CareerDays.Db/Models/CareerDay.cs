using System;
using BuildingBlocks.Database.EntityFramework.Models;

namespace CareerDays.Db.Models
{
    /// <summary>
    ///     День карьеры
    /// </summary>
    public class CareerDay : RelationalDictionary
    {
        /// <summary>
        ///     Описание
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        ///     Id Брендированного шаблона
        /// </summary>
        public virtual long? BrandedDescriptionId { get; set; }

        /// <summary>
        ///     Дата начала
        /// </summary>
        public virtual DateTime StartsAt { get; set; }

        /// <summary>
        ///     Id Организации
        /// </summary>
        public virtual long? EmployerId { get; set; }

        /// <summary>
        ///     Образовательное учреждение
        /// </summary>
        public virtual long EducationalInstitutionId { get; set; }
    }
}