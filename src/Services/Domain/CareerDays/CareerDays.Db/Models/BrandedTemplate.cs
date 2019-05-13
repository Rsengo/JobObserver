using BuildingBlocks.EntityFramework.Models;

namespace CareerDays.Db.Models
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

        public virtual long CareerDayId { get; set; }

        public virtual CareerDay CareerDay { get; set; }
    }
}