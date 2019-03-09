using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EntityFramework.Models;

namespace Vacancies.Db.Models.Employers
{
    public class Department : RelationalDictionary
    {
        /// <summary>
        ///     Организация
        /// </summary>
        public virtual Employer Organization { get; set; }

        /// <summary>
        ///     Id Организации
        /// </summary>
        public virtual long OrganizationId { get; set; }
    }
}
