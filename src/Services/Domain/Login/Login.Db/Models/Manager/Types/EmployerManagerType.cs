using System.Collections.Generic;
using Login.Db.Models.Manager.Permissions;

namespace Login.Db.Models.Manager.Types
{
    /// <summary>
    ///     Тип менеджера работодателя
    /// </summary>
    public class EmployerManagerType : BaseManagerType
    {
        /// <summary>
        ///     Возможности, привилегии
        /// </summary>
        public virtual ICollection<EmployerManagerPermission> AvailablePermissions { get; set; }

        /// <summary>
        ///     Id Организации
        /// </summary>
        public virtual long OrganizationId { get; set; }
    }
}