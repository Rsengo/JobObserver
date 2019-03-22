using System.Collections.Generic;
using BuildingBlocks.EntityFramework.Models;

namespace Login.Db.Models.Contacts
{
    /// <summary>
    ///     Контакты
    /// </summary>
    public class Contact : RelationalEntity
    {
        /// <summary>
        ///     Телефон
        /// </summary>
        public virtual Phone Phone { get; set; }

        /// <summary>
        ///     Id Телефона
        /// </summary>
        public virtual long PhoneId { get; set; }

        /// <summary>
        ///     Доп. телефон
        /// </summary>
        public virtual Phone AdditionalPhone { get; set; }

        /// <summary>
        ///     Id Доп. телефона
        /// </summary>
        public virtual long? AdditionalPhoneId { get; set; }

        /// <summary>
        ///     Другие контакты
        /// </summary>
        public virtual ICollection<Site> Sites { get; set; }

        public virtual User User { get; set; }

        public virtual string UserId { get; set; }
    }
}