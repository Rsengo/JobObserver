using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EntityFramework.Models;

namespace CareerDays.Db.Models
{
    public class Employer: RelationalDictionary
    {
        /// <summary>
        ///     Логотип
        /// </summary>
        public virtual string LogoUrl { get; set; }

        /// <summary>
        ///     Сайт компании
        /// </summary>
        public virtual string SiteUrl { get; set; }
    }
}
