using BuildingBlocks.Database.EntityFramework.Models;
using Geographic.Db.Models.Metro;

namespace Geographic.Db.Models
{
    /// <summary>
    ///     Адрес
    /// </summary>
    public class Address : RelationalEntity
    {
        /// <summary>
        ///     Город
        /// </summary>
        public virtual Area Area { get; set; }

        /// <summary>
        ///     Id Города
        /// </summary>
        public virtual long AreaId { get; set; }

        /// <summary>
        ///     Улица
        /// </summary>
        public virtual string Street { get; set; }

        /// <summary>
        ///     Номер здания
        /// </summary>
        public virtual string Building { get; set; }

        /// <summary>
        ///     Описание
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        ///     Ширина (географически)
        /// </summary>
        public virtual double Latitude { get; set; }

        /// <summary>
        ///     Долгота (географически)
        /// </summary>
        public virtual double Longitude { get; set; }

        /// <summary>
        ///     Станция метро
        /// </summary>
        public virtual Station Station { get; set; }

        /// <summary>
        ///     Id Станции метро
        /// </summary>
        public virtual long? StationId { get; set; }
    }
}