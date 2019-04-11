using System;
using BuildingBlocks.EntityFramework.Models;
using CareerDays.Db.Models.Geographic;

namespace CareerDays.Db.Models
{
    using System.Collections.Generic;

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
        public virtual long EmployerId { get; set; }

        /// <summary>
        ///     Организация.   
        /// </summary>
        public virtual ICollection<CareerDayEmployer> Employers { get; set; }

        /// <summary>
        ///     Образовательное учреждение Id
        /// </summary>
        public virtual long? EducationalInstitutionId { get; set; }

        /// <summary>
        ///     Образовательное учреждение.
        /// </summary>
        public virtual ICollection<CareerDayEducationalInstitution> EducationalInstitutions { get; set; }

        /// <summary>
        ///     Адрес.
        /// </summary>
        public virtual Address Address { get; set; }

        /// <summary>
        ///     Id адреса.
        /// </summary>
        public virtual long AddressId { get; set; }
    }
}