﻿using System.Collections.Generic;
using Login.Db.Models.Manager.Permissions;
using Login.Db.Models.Manager.Types;

namespace Login.Db.Models.Manager
{
    /// <summary>
    ///     Менеджер работодателя
    /// </summary>
    public class EmployerManager : BaseManager
    {
        /// <summary>
        ///     Id Организации
        /// </summary>
        public virtual long OrganizationId { get; set; }

        /// <summary>
        ///     Тип менеджера
        /// </summary>
        public virtual EmployerManagerType ManagerType { get; set; }

        /// <summary>
        ///     Id Типа менеджера
        /// </summary>
        public virtual long? ManagerTypeId { get; set; }

        /// <summary>
        ///     Доп. возможности
        /// </summary>
        public virtual ICollection<EmployerManagerPermission> Permissions { get; set; }
    }
}