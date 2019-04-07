using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moodle.Integration.Models.CreateCourse
{
    class CreateCourseResponse
    {
        /// <summary>
        /// <param name="CourseId">Course id.</param> 
        /// </summary>
        [JsonProperty("id")]
        public int CourseId { get; set; }


        /// <summary>
        /// <param name="ShortName">Short name of the course.</param> 
        /// </summary>
        [JsonProperty("shortname")]
        public string ShortName { get; set; }
    }
}
