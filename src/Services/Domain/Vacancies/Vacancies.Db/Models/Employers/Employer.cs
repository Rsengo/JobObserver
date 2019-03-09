using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EntityFramework.Models;
using Vacancies.Db.Models.Geographic;

namespace Vacancies.Db.Models.Employers
{
    public class Employer : RelationalDictionary
    {
        /// <summary>
        ///     Id Города
        /// </summary>
        public virtual long? AreaId { get; set; }

        public virtual Area Area { get; set; }

        /// <summary>
        ///     Сокращение от названия
        /// </summary>
        public virtual string Acronym { get; set; }

        /// <summary>
        ///     Логотип
        /// </summary>
        public virtual string LogoUrl { get; set; }

        /// <summary>
        ///     Сайт компании
        /// </summary>
        public virtual string SiteUrl { get; set; }

        public virtual ICollection<Vacancy> Vacancies { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
    }
}
