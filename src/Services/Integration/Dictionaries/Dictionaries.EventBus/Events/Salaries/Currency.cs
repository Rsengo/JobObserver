using BuildingBlocks.DataTransfer.Models;

namespace Dictionaries.Dto.Models.Salaries
{
    /// <summary>
    ///     Валюта
    /// </summary>
    public class Currency : DtoDictionary
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