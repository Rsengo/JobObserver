using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Moodle.Integration.Models.Auth
{

    // core_auth_confirm_user
    public class AuthRequest : MoodleRequest
    {
        /// <summary>
        /// <param name="UserName"> User Name.</param> 
        /// </summary>
        [Required]
        [JsonProperty("username")]
        public string UserName { get; set; }

        /// <summary>
        /// <param name="Secret"> Confirmation secret.</param> 
        /// </summary>
        [Required]
        [JsonProperty("secret")]
        public string Secret { get; set; }
    }
}
