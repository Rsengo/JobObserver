using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Login.API.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [JsonProperty("email")]
        public string Email { get; set; }

        [Required]
        [JsonProperty("password")]
        public string Password { get; set; }

        [Required]
        [JsonProperty("remember_me")]
        public bool RememberMe { get; set; }

        [Required]
        [JsonProperty("return_url")]
        public string ReturnUrl { get; set; }
    }
}
