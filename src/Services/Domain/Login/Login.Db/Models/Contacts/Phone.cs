using System.ComponentModel.DataAnnotations.Schema;
using BuildingBlocks.EntityFramework.Models;

namespace Login.Db.Models.Contacts
{
    /// <summary>
    ///     Телефон
    /// </summary>
    public class Phone : RelationalEntity
    {
        /// <summary>
        ///     Номер страны
        /// </summary>
        public virtual string Country { get; set; }

        /// <summary>
        ///     Номер города
        /// </summary>
        public virtual string City { get; set; }

        /// <summary>
        ///     Номер
        /// </summary>
        public virtual string Number { get; set; }

        /// <summary>
        ///     Комметарий
        /// </summary>
        public virtual string Comment { get; set; }

        /// <summary>
        ///     Полный номер
        /// </summary>
        [NotMapped]
        public virtual string Raw => $"{Country}{City}{Number}";
    }
}