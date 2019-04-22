using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Login.API.ViewModels
{
    public class LogoutViewModel
    {
        [Required]
        [JsonProperty("logout_id")]
        public string LogoutId { get; set; }
    }
}
