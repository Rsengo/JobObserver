using Moodle.Integration.Models.GetUser;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Moodle.Integration.Models.Registration
{
    //auth_email_signup_user
    public class RegistrationRequest : MoodleRequest
    {
        public override string Function => "auth_email_signup_user";

        /// <summary>
        /// <param name="UserName"> User Name.</param> 
        /// </summary>
        [Required]
        [JsonProperty("username")]
        public string UserName { get; set; }

        /// <summary>
        /// <param name="Password"> Plain text password.</param> 
        /// </summary>
        [Required]
        [JsonProperty("password")]
        public string Password { get; set; }

        /// <summary>
        /// <param name="FirstName"> The first name(s) of the user.</param> 
        /// </summary>
        [Required]
        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        /// <summary>
        /// <param name="LastName"> The family name of the user.</param> 
        /// </summary>
        [Required]
        [JsonProperty("lastname")]
        public string LastName { get; set; }

        /// <summary>
        /// <param name="Email"> A valid and unique email addressr.</param> 
        /// </summary>
        [Required]
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// <param name="City"> Home city of the user. Default is empty</param> 
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// <param name="Country"> Home county code. Default is empty</param> 
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        /// <param name="RecaptchaChallengeHash">  Recaptcha challenge hash. Default is empty</param> 
        /// </summary>
        [JsonProperty("recaptchachallengehash")]
        public string RecaptchaChallengeHash { get; set; }

        /// <summary>
        /// <param name="RecaptchaResponse">  Recaptcha response. Default is empty</param> 
        /// </summary>
        [JsonProperty("recaptcharesponse")]
        public string RecaptchaResponse { get; set; }

        // <summary>
        /// <param name="CustomFields"> User custom fields (also known as user profile fields). Default is empty.</param> 
        /// </summary>
        [JsonProperty("customfields")]
        public ICollection<ProfileField> CustomFields { get; set; }


        // <summary>
        /// <param name="Redirect">  Redirect the user to this site url after confirmation. Default is empty.</param> 
        /// </summary>
        [JsonProperty("redirect")]
        public string Redirect { get; set; }

        public RegistrationRequest()
        {
            CustomFields = new List<ProfileField>();
        }
    }
}
