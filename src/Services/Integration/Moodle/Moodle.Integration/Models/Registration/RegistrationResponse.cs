using Moodle.Integration.Models.GetUser;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moodle.Integration.Models.Registration
{
    public class RegistrationResponse
    {
        /// <summary>
        /// <param name="Success"> True if the user was created false otherwise.</param> 
        /// </summary>
        [JsonProperty("success")]
        public int Success { get; set; }

        /// <summary>
        /// <param name="Warnings"> List of warnings.</param> 
        /// </summary>
        [JsonProperty("warnings")]
        public ICollection<Warning> Warnings { get; set; }
    }
}
