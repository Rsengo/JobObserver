using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Moodle.Integration.Models.GetUser
{
    public class ProfileField
    {
        /// <summary>
        /// <param name="Type"> The type of the custom field - text field, checkbox...</param> 
        /// </summary>
        [Required]
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// <param name="Value"> The value of the custom field</param> 
        /// </summary>
        [Required]
        [JsonProperty("value")]
        public string Value { get; set; }

        /// <summary>
        /// <param name="Name"> The name of the custom field</param> 
        /// </summary>
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// <param name="ShortName"> The shortname of the custom field - to be able to build the field class in the code</param> 
        /// </summary>
        [JsonProperty("shortname")]
        public string ShortName { get; set; }
    }

    public class Preference
    {
        /// <summary>
        /// <param name="Name"> The name of the preferences</param> 
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// <param name="Value"> The value of the preference</param> 
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class Warning
    {
        /// <summary>
        /// <param name="Item"> Always set to 'key'. Optional</param> 
        /// </summary>
        [JsonProperty("item")]
        public string Item { get; set; }

        /// <summary>
        /// <param name="ItemId"> Faulty key name. Optional</param> 
        /// </summary>
        [JsonProperty("itemid")]
        public int? ItemId { get; set; }

        /// <summary>
        /// <param name="WarningCode"> the warning code can be used by the client app to implement specific behaviour</param> 
        /// </summary>
        [JsonProperty("warningcode")]
        public string WarningCode { get; set; }

        /// <summary>
        /// <param name="Message"> Untranslated english message to explain the warning</param> 
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public class GetUserResponse
    {
        /// <summary>
        /// <param name="UserId"> ID of the user.</param> 
        /// </summary>
        [JsonProperty("id")]
        public string UserId { get; set; }

        /// <summary>
        /// <param name="UserName"> The username. Optional.</param> 
        /// </summary>
        [JsonProperty("username")]
        public string UserName { get; set; }

        /// <summary>
        /// <param name="FirstName"> The first name of the user. Optional.</param> 
        /// </summary>
        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        /// <summary>
        /// <param name="LastName"> The family name of the user. Optional.</param> 
        /// </summary>
        [JsonProperty("lastname")]
        public string LastName { get; set; }

        /// <summary>
        /// <param name="FullName"> The family name of the user.</param> 
        /// </summary>
        [JsonProperty("fullname")]
        public string FullName { get; set; }

        /// <summary>
        /// <param name="Email"> An email address - allow email as root@localhost. Optional.</param> 
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// <param name="Address"> Postal address. Optional.</param> 
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }

        /// <summary>
        /// <param name="Phone1"> Phone1. Optional.</param> 
        /// </summary>
        [JsonProperty("phone1")]
        public string Phone1 { get; set; }

        /// <summary>
        /// <param name="Phone2"> Phone2. Optional.</param> 
        /// </summary>
        [JsonProperty("phone2")]
        public string Phone2 { get; set; }

        /// <summary>
        /// <param name="Icq"> icq number. Optional.</param> 
        /// </summary>
        [JsonProperty("icq")]
        public string Icq { get; set; }

        /// <summary>
        /// <param name="Skype"> skype id. Optional.</param> 
        /// </summary>
        [JsonProperty("skype")]
        public string Skype { get; set; }

        /// <summary>
        /// <param name="Yahoo"> yahoo id. Optional.</param> 
        /// </summary>
        [JsonProperty("yahoo")]
        public string Yahoo { get; set; }

        /// <summary>
        /// <param name="Aim"> Aim. Optional.</param> 
        /// </summary>
        [JsonProperty("aim")]
        public string Aim { get; set; }

        /// <summary>
        /// <param name="Msn"> Msn. Optional.</param> 
        /// </summary>
        [JsonProperty("msn")]
        public string Msn { get; set; }

        /// <summary>
        /// <param name="Department"> Department. Optional.</param> 
        /// </summary>
        [JsonProperty("department")]
        public string Department { get; set; }


        /// <summary>
        /// <param name="Institution"> Institution. Optional.</param> 
        /// </summary>
        [JsonProperty("institution")]
        public string Institution { get; set; }

        /// <summary>
        /// <param name="IdNumber"> An arbitrary ID code number perhaps from the institution. Optional.</param> 
        /// </summary>
        [JsonProperty("idnumber")]
        public string IdNumber { get; set; }

        /// <summary>
        /// <param name="Interests"> User interests (separated by commas). Optional.</param> 
        /// </summary>
        [JsonProperty("interests")]
        public string Interests { get; set; }

        /// <summary>
        /// <param name="FirstAccess"> First access to the site (0 if never). Optional.</param> 
        /// </summary>
        [JsonProperty("firstaccess")]
        public int? FirstAccess { get; set; }

        /// <summary>
        /// <param name="LastAccess"> Last access to the site (0 if never). Optional.</param> 
        /// </summary>
        [JsonProperty("lastaccess")]
        public int? LastAccess { get; set; }

        /// <summary>
        /// <param name="Auth"> Auth plugins include manual, ldap, etc. Optional.</param> 
        /// </summary>
        [JsonProperty("auth")]
        public string Auth { get; set; }

        /// <summary>
        /// <param name="Suspended"> Suspend user account, either false to enable user login or true to disable it. Optional.</param> 
        /// </summary>
        [JsonProperty("suspended")]
        public int? Suspended { get; set; }

        /// <summary>
        /// <param name="Confirmed"> Active user: 1 if confirmed, 0 otherwise. Optional.</param> 
        /// </summary>
        [JsonProperty("confirmed")]
        public int? Confirmed { get; set; }

        /// <summary>
        /// <param name="Lang"> Language code such as "en", must exist on server. Optional.</param> 
        /// </summary>
        [JsonProperty("lang")]
        public string Lang { get; set; }

        /// <summary>
        /// <param name="CalendarType"> Calendar type such as "gregorian", must exist on server. Optional.</param> 
        /// </summary>
        [JsonProperty("calendartype")]
        public string CalendarType { get; set; }

        /// <summary>
        /// <param name="Theme"> Theme name such as "standard", must exist on server. Optional.</param> 
        /// </summary>
        [JsonProperty("theme")]
        public string Theme { get; set; }

        /// <summary>
        /// <param name="Timezone"> Timezone code such as Australia/Perth, or 99 for default. Optional.</param> 
        /// </summary>
        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        /// <summary>
        /// <param name="MailFormat"> Mail format code is 0 for plain text, 1 for HTML etc. Optional.</param> 
        /// </summary>
        [JsonProperty("mailformat")]
        public int? MailFormat { get; set; }

        /// <summary>
        /// <param name="Description"> User profile description. Optional.</param> 
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// <param name="DescriptionFormat"> int format (1 = HTML, 0 = MOODLE, 2 = PLAIN or 4 = MARKDOWN). Optional.</param> 
        /// </summary>
        [JsonProperty("descriptionformat")]
        public int? DescriptionFormat { get; set; }

        /// <summary>
        /// <param name="City"> Home city of the user. Optional.</param> 
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// <param name="Url"> URL of the user. Optional.</param> 
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// <param name="Country"> Home country code of the user, such as AU or CZ. Optional.</param> 
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        /// <param name="ProfileImageUrlSmall"> User image profile URL - small version.</param> 
        /// </summary>
        [JsonProperty("profileimageurlsmall")]
        public string ProfileImageUrlSmall { get; set; }

        // <summary>
        /// <param name="ProfileImageUrl"> User image profile URL - big version.</param> 
        /// </summary>
        [JsonProperty("profileimageurl")]
        public string ProfileImageUrl { get; set; }

        // <summary>
        /// <param name="CustomFields"> User custom fields (also known as user profile fields). Optional.</param> 
        /// </summary>
        [JsonProperty("customfields")]
        public ICollection<ProfileField> CustomFields { get; set; }

        // <summary>
        /// <param name="Preferences"> Users preferences. Optional.</param> 
        /// </summary>
        [JsonProperty("preferences")]
        public ICollection<Preference> Preferences { get; set; }

        // <summary>
        /// <param name="Warnings  "> List of warnings. Optional.</param> 
        /// </summary>
        [JsonProperty("warnings")]
        public ICollection<Warning> Warnings { get; set; }

    }
}
