using System.Collections.Generic;
using BuildingBlocks.Database.EntityFramework.Models;

namespace Geographic.Db.Models.Metro
{
    /// <summary>
    ///     Ветка метро
    /// </summary>
    public class Line : RelationalEntity
    {
        /// <summary>
        ///     Цвет в шестнадцетиричной системе
        /// </summary>
        public virtual int HexColor { get; set; }

        /// <summary>
        ///     Метро
        /// </summary>
        public virtual Metro Metro { get; set; }

        /// <summary>
        ///     Метро
        /// </summary>
        public virtual long MetroId { get; set; }

        /// <summary>
        ///     Станции
        /// </summary>
        public virtual ICollection<Station> Stations { get; set; }
    }
}