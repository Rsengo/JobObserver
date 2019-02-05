using System;
using BuildingBlocks.Database.EntityFramework.Models;

namespace Negotiations.Db.Negotiations
{
    /// <summary>
    ///     Отзыв
    /// </summary>
    public abstract class BaseNegotiation : RelationalEntity
    {
        /// <summary>
        ///     Сообщение
        /// </summary>
        public virtual string Message { get; set; }

        /// <summary>
        ///     Ответ на отзыв
        /// </summary>
        public virtual Response Response { get; set; }

        /// <summary>
        ///     Id Ответа на отзыв
        /// </summary>
        public virtual long? ResponseId { get; set; }

        /// <summary>
        ///     Дата
        /// </summary>
        public virtual DateTime Date { get; set; }
    }
}