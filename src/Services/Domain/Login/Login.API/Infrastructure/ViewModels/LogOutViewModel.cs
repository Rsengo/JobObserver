using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Login.API.Infrastructure.ViewModels
{
    public class LogOutViewModel
    {
        [Required]
        [JsonProperty("logout_id")]
        public string LogoutId { get; set; }
    }
}
