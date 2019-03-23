using System.Collections.Generic;
using BuildingBlocks.EntityFramework.Models;

namespace Login.Db.Models.Contacts
{
    /// <summary>
    ///     Контакты
    /// </summary>
    public class Contact : RelationalEntity
    {
        public virtual ICollection<Phone> Phones { get; set; }

        /// <summary>
        ///     Другие контакты
        /// </summary>
        public virtual ICollection<Site> Sites { get; set; }

        public virtual User User { get; set; }

        public virtual string UserId { get; set; }
    }
}