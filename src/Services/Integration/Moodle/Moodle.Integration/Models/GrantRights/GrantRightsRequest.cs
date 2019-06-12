using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Moodle.Integration.Models.GrantRights
{
    public class Assignment
    {
        /// <summary>
        /// <param name="RoleId"> Role to assign to the user.</param> 
        /// </summary>
        [Required]
        [JsonProperty("roleid")]
        public int RoleId { get; set; }

        /// <summary>
        /// <param name="UserId"> The user that is going to be assigned.</param> 
        /// </summary>
        [Required]
        [JsonProperty("userid")]
        public int UserId { get; set; }

        /// <summary>
        /// <param name="ContextId"> The context to assign the user role in. OPTIONAL.</param> 
        /// </summary>
        [JsonProperty("contextid")]
        public int? ContextId { get; set; }

        /// <summary>
        /// <param name="ContextLevel"> The context level to assign the user role in (block, course, coursecat, system, user, module). OPTIONAL.</param> 
        /// </summary>
        [JsonProperty("contextlevel")]
        public string ContextLevel { get; set; }

        /// <summary>
        /// <param name="InstanceId"> The Instance id of item where the role needs to be assigned. OPTIONAL.</param> 
        /// </summary>
        [JsonProperty("instanceid")]
        public int? InstanceId { get; set; }
    }

    //core_role_assign_roles
    public class GrantRightsRequest : MoodleRequest
    {
        /// <summary>
        /// <param name="Assignments"> List of assignments.</param> 
        /// </summary>
        [Required]
        [JsonProperty("assignments")]
        public ICollection<Assignment> Assignments { get; set; }

        public override string Function => "core_role_assign_roles";

        public void AddSingleAssignment(Assignment assignment)
        {
            if (Assignments == null)
                Assignments = new List<Assignment>();
            Assignments.Add(assignment);
        }

        // auto sets contextlevel to course
        public void AddSingleAssignmentToCourse(Assignment assignment)
        {
            assignment.ContextLevel = "course";
            AddSingleAssignment(assignment);
        }
    }
}
