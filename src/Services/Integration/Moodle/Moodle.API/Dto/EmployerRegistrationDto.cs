using BuildingBlocks.DataTransfer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Moodle.API.Dto
{
    public class EmployerRegistrationDto: DtoDictionary
    {
        /// <summary>
        /// Id компании.
        /// </summary>
        [Required]
        public override long Id { get; set; }

        /// <summary>
        /// Название компании.
        /// </summary>
        [Required]
        public override string Name { get; set; }
        /// <summary>
        /// <param name="Password"> Plain text password.</param> 
        /// </summary>
        [Required]
        [JsonProperty("password")]
        public string Password { get; set; }

        /// <summary>
        /// <param name="Password"> Plain text password.</param> 
        /// </summary>
        [Required]
        [Compare(nameof(Password))]
        [JsonProperty("confirm_password")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// <param name="Email"> A valid and unique email addressr.</param> 
        /// </summary>
        [Required]
        [EmailAddress]
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
