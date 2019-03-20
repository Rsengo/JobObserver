using System;
using BuildingBlocks.EntityFramework.Models;

namespace Vacancies.Db.Models.Negotiations
{
    /// <summary>
    ///     Оклик на вакансию
    /// </summary>
    public class VacancyNegotiation : RelationalEntity
    {
        /// <summary>
        ///     Id Соискателя, оставившего отзыв
        /// </summary>
        public virtual Guid ApplicantId { get; set; }

        /// <summary>
        ///     Id Вакансии
        /// </summary>
        public virtual long VacancyId { get; set; }

        public virtual Vacancy Vacancy { get; set; }

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