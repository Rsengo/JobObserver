using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EntityFramework.Models;

namespace Employers.Db.Models.EducationalInstitutions
{
    public class EducationalInstitution: RelationalDictionary
    {
        /// <summary>
        ///     Логотип
        /// </summary>
        public virtual string LogoUrl { get; set; }

        /// <summary>
        ///     Сайт компании
        /// </summary>
        public virtual string SiteUrl { get; set; }

        /// <summary>
        ///     Сокращение от названия
        /// </summary>
        public virtual string Acronym { get; set; }
    }
}
