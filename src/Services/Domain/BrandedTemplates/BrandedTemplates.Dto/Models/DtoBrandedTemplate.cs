using BuildingBlocks.Database.Entity;

namespace BrandedTemplates.Dto.Models
{
    /// <summary>
    ///     Брендированный шаблон
    /// </summary>
    public class DtoBrandedTemplate : BaseEntity<long>
    {
        /// <summary>
        ///     Название.
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        ///     HTML шаблон
        /// </summary>
        public virtual string Text { get; set; }
    }
}