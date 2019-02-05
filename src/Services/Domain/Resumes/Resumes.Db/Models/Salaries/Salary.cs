using BuildingBlocks.Database.EntityFramework.Models;

namespace Resumes.Db.Models.Salaries
{
    /// <summary>
    ///     Заработная плата
    /// </summary>
    public class Salary : RelationalEntity
    {
        /// <summary>
        ///     Валюта
        /// </summary>
        public virtual Currency Currency { get; set; }

        /// <summary>
        ///     Id Валюты
        /// </summary>
        public virtual long? CurrencyId { get; set; }

        /// <summary>
        ///     Нижняя граница
        /// </summary>
        public virtual decimal From { get; set; }

        /// <summary>
        ///     Верхняя граница
        /// </summary>
        public virtual decimal To { get; set; }
    }
}