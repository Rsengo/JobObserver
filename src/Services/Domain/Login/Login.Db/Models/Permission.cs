using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EntityFramework.Models;

namespace Login.Db.Models
{
    public class Permission : RelationalEntity
    {
        public string Value { get; set; }

        public string Type { get; set; }
    }
}
