using BuildingBlocks.DataTransfer.Models;
using Newtonsoft.Json;

namespace PaidServices.Db.Dto.Models
{
    /// <summary>
    ///     Базовый платный сервис
    /// </summary>
    public abstract class DtoBasePaidService : DtoDictionary
    {
        /// <summary>
        ///     Цена
        /// </summary>
        [JsonProperty("price")]
        public virtual double Price { get; set; }
    }
}