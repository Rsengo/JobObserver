using BuildingBlocks.EntityFramework.Models;
using BuildingBlocks.EntityFramework.Models;

namespace PaidServices.Db.Models
{
    /// <summary>
    ///     Базовый платный сервис
    /// </summary>
    public abstract class BasePaidService : RelationalDictionary
    {
        /// <summary>
        ///     Цена
        /// </summary>
        public virtual double Price { get; set; }
    }
}