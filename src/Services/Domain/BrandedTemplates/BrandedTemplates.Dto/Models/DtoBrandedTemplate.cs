namespace BrandedTemplates.Dto.Models
{
    /// <summary>
    ///     Брендированный шаблон
    /// </summary>
    public class DtoBrandedTemplate
    {

        /// <summary>
        ///     Id сущности.
        /// </summary>
        public virtual long Id { get; set; }

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