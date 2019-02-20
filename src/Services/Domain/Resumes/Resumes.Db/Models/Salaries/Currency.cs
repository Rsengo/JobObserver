using BuildingBlocks.EntityFramework.Models;
using BuildingBlocks.EntityFramework.Models;

namespace Resumes.Db.Models.Salaries
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