﻿using System.Collections.Generic;
using BuildingBlocks.DataTransfer.Models;
using Newtonsoft.Json;

namespace Resumes.Db.Dto.Models.Specializations
{
    /// <summary>
    ///     Специализация
    /// </summary>
    public class DtoSpecialization : DtoDictionary
    {
        /// <summary>
        ///     Родитель.
        /// </summary>
        [JsonProperty("parent")]
        public virtual DtoSpecialization Parent { get; set; }

        /// <summary>
        ///     Id родителя.
        /// </summary>
        [JsonProperty("parent_id")]
        public virtual long? ParentId { get; set; }
    }
}