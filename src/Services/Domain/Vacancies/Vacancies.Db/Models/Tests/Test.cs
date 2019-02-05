using BuildingBlocks.Database.EntityFramework.Models;

namespace Vacancies.Db.Models.Tests
{
    /// <summary>
    ///     Тест
    /// </summary>
    public class Test : RelationalDictionary
    {
        /// <summary>
        ///     Ссылка
        /// </summary>
        public virtual string Url { get; set; }

        /// <summary>
        /// Вакансия.
        /// </summary>
        public virtual Vacancy Vacancy { get; set; }

        /// <summary>
        /// Id вакансии.
        /// </summary>
        public virtual long VacancyId { get; set; }
    }
}