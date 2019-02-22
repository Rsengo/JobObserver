using System.Collections.Generic;
using BuildingBlocks.DataTransfer.Models;

namespace Dictionaries.Dto.Models.Geographic.Metro
{
    /// <summary>
    ///     Ветка метро
    /// </summary>
    public class Line : DtoEntity
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