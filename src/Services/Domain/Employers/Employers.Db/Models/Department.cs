using BuildingBlocks.Database.EntityFramework.Models;
using BuildingBlocks.Database.EntityFramework.Models;

namespace Employers.Db.Models
{
    /// <summary>
    ///     Отдел
    /// </summary>
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