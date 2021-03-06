﻿using System.Collections.Generic;
using BuildingBlocks.EntityFramework.Models;

namespace Resumes.Db.Models.Industries
{
    /// <summary>
    ///     Сфера деятельности
    /// </summary>
    public class Industry : RelationalDictionary
    {
        /// <summary>
        ///     Родитель.
        /// </summary>
        public virtual Industry Parent { get; set; }

        /// <summary>
        ///     Id родителя.
        /// </summary>
        public virtual long? ParentId { get; set; }

        /// <summary>
        ///     Дочерние.
        /// </summary>
        public virtual ICollection<Industry> Industries { get; set; }
    }
}