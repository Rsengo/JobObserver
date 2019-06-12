using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Moodle.Integration.Models.SubUserToCourse
{
    public class Enrolment
    {
        /// <summary>
        /// <param name="RoleId"> Role to assign to the user.</param> 
        /// </summary>
        [Required]
        [JsonProperty("roleid")]
        public int RoleId { get; set; }

        /// <summary>
        /// <param name="UserId"> The user that is going to be enrolled.</param> 
        /// </summary>
        [Required]
        [JsonProperty("userid")]
        public int UserId { get; set; }

        /// <summary>
        /// <param name="CourseId"> The course to enrol the user role in.</param> 
        /// </summary>
        [Required]
        [JsonProperty("courseid")]
        public int CourseId { get; set; }

        /// <summary>
        /// <param name="TimeStart"> Timestamp when the enrolment start. OPTIONAL.</param> 
        /// </summary>
        [JsonProperty("timestart")]
        public int? TimeStart { get; set; }

        /// <summary>
        /// <param name="TimeEnd"> Timestamp when the enrolment end. OPTIONAL.</param> 
        /// </summary>
        [JsonProperty("timeend")]
        public int? TimeEnd { get; set; }

        /// <summary>
        /// <param name="Suspend"> Set to 1 to suspend the enrolment. OPTIONAL.</param> 
        /// </summary>
        [JsonProperty("suspend")]
        public int? Suspend { get; set; }
    }


    // used enrol_manual_enrol_users. Possible to use core_enrol_edit_user_enrolment
    public class SubUserToCourseRequest : MoodleRequest
    {
        /// <summary>
        /// <param name="Enrolments"> List of enrolments.</param> 
        /// </summary>
        [Required]
        [JsonProperty("enrolments")]
        public ICollection<Enrolment> Enrolments { get; set; }

        public override string Function => "enrol_manual_enrol_users";

        public void AddSingleEnrolment(Enrolment enrolment)
        {
            if (Enrolments == null)
                Enrolments = new List<Enrolment>();
            Enrolments.Add(enrolment);
        }
    }
}
