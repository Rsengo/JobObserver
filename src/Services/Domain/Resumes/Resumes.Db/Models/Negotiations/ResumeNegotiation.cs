using System;
using BuildingBlocks.EntityFramework.Models;

namespace Resumes.Db.Models.Negotiations
{
    /// <summary>
    ///     Отклик на резюме
    /// </summary>
    public class ResumeNegotiation : RelationalEntity
    {
        /// <summary>
        ///     Id Компании
        /// </summary>
        public virtual long CompanyId { get; set; }

        /// <summary>
        ///     Id Резюме
        /// </summary>
        public virtual long ResumeId { get; set; }

        public virtual Resume Resume { get; set; }

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