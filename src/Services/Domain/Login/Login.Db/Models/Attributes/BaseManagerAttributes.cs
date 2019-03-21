using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EntityFramework.Models;

namespace Login.Db.Models.Attributes
{
    public abstract class BaseManagerAttributes : RelationalEntity
    {
        /// <summary>
        ///     Должность
        /// </summary>
        public virtual string Position { get; set; }

        /// <summary>
        ///     Id Организации
        /// </summary>
        public virtual long OrganizationId { get; set; }
    }
}
