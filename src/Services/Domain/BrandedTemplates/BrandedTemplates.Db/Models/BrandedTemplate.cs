using BuildingBlocks.Database.EntityFramework.Models;
using BuildingBlocks.Database.MongoDB.Models;

namespace BrandedTemplates.Db.Models
{
    /// <summary>
    ///     Брендированный шаблон
    /// </summary>
    public class BrandedTemplate : MongoEntity
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