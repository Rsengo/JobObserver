using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employers.API.Filters
{
    using Newtonsoft.Json;

    public class DepartmentSearchFilter : SearchFilter
    {
        [JsonProperty("employer_id")]
        public long EmployerId { get; set; }
    }
}
