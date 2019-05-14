using BuildingBlocks.EntityFramework.Models;

namespace Vacancies.Db.Models.BrandedTemplates
{
    /// <summary>
    ///     Брендированный шаблон
    /// </summary>
    public class BrandedTemplate : RelationalEntity
    {
        /// <summary>
        ///     Название.
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        ///     HTML шаблон
        /// </summary>
        public virtual string Text { get; set; }

        public virtual Vacancy Vacancy { get; set; }

        public virtual long VacancyId { get; set; }
    }
}