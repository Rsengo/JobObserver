using BuildingBlocks.EntityFramework.Models;

namespace Login.Db.Models.Contacts
{
    /// <summary>
    ///     Сайт (соцсеть, месседжер)
    /// </summary>
    public class Site : RelationalEntity
    {
        /// <summary>
        ///     Тип
        /// </summary>
        public virtual SiteType Type { get; set; }

        /// <summary>
        ///     Id Типа
        /// </summary>
        public virtual long? TypeId { get; set; }

        /// <summary>
        ///     Значение (ссылка)
        /// </summary>
        public virtual string Value { get; set; }

        /// <summary>
        ///     Является ли предпочтительным
        /// </summary>
        public virtual bool IsPreferred { get; set; }
    }
}