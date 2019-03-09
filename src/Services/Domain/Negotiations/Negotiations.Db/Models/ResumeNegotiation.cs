using System;
using BuildingBlocks.EntityFramework.Models;

namespace Negotiations.Db.Models
{
    /// <summary>
    ///     Отклик на резюме
    /// </summary>
    public class ResumeNegotiation : RelationalEntity
    {
        /// <summary>
        ///     Id Менеджера, оставившего отклик
        /// </summary>
        public virtual long ManagerId { get; set; }

        /// <summary>
        ///     Id Резюме
        /// </summary>
        public virtual long ResumeId { get; set; }

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