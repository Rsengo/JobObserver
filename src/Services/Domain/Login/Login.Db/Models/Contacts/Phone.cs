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
        ///     Номер
        /// </summary>
        public virtual string Number { get; set; }

        /// <summary>
        ///     Комметарий
        /// </summary>
        public virtual string Comment { get; set; }

        public virtual Contact Contact { get; set; }

        public virtual long ContactId { get; set; }
    }
}