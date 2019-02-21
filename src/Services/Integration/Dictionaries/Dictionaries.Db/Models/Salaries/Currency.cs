using BuildingBlocks.EntityFramework.Models;

namespace Dictionaries.Db.Models.Salaries
{
    /// <summary>
    ///     Валюта
    /// </summary>
    public class Currency : RelationalDictionary
    {
        /// <summary>
        ///     Аббревиатура
        /// </summary>
        public virtual string Abbr { get; set; }

        /// <summary>
        ///     Кодовое название
        /// </summary>
        public virtual string Code { get; set; }
    }
}