using BuildingBlocks.EntityFramework.Models;

namespace Vacancies.Db.Models.Geographic.Metro
{
    /// <summary>
    ///     Станция
    /// </summary>
    public class Station : RelationalEntity
    {
        /// <summary>
        ///     Название
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        ///     Ширина (географически)
        /// </summary>
        public virtual double Latitude { get; set; }

        /// <summary>
        ///     Долгота (географически)
        /// </summary>
        public virtual double Longitude { get; set; }

        /// <summary>
        ///     Номер
        /// </summary>
        public virtual int Order { get; set; }

        /// <summary>
        ///     Линия
        /// </summary>
        public virtual Line Line { get; set; }

        /// <summary>
        ///     Линия
        /// </summary>
        public virtual long LineId { get; set; }
    }
}