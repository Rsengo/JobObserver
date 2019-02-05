using System.Collections.Generic;
using BuildingBlocks.Database.EntityFramework.Models;
using BuildingBlocks.Database.EntityFramework.Models;

namespace Resumes.Db.Models.Specializations
{
    /// <summary>
    ///     Специализация
    /// </summary>
    public class Specialization : RelationalDictionary
    {
        /// <summary>
        ///     Родитель.
        /// </summary>
        public virtual Specialization Parent { get; set; }

        /// <summary>
        ///     Id родителя.
        /// </summary>
        public virtual long? ParentId { get; set; }

        /// <summary>
        ///     Дочерние.
        /// </summary>
        public virtual ICollection<Specialization> Specializations { get; set; }
    }
}