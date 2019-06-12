using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

// core_course_create_courses

namespace Moodle.Integration.Models.CreateCourse
{
    public class CourseFormatOption
    {
        /// <summary>
        /// <param name="Name"> Course format option name.</param> 
        /// </summary>
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// <param name="Value"> Course format option value.</param> 
        /// </summary>
        [Required]
        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class Course
    {
        public Course() // setting default values
        {
            SummaryFormat = 1;
            Format = "topics";
            ShowGrades = 1;
            NewsItems = 5;
            Maxbytes = 0;
            ShowReports = 0;
            GroupMode = 0;
            GroupModeForce = 0;
            DefaultGroupingId = 0;
        }

        /// <summary>
        /// <param name="FullName">Full name of the course.</param> 
        /// </summary>
        [Required]
        [JsonProperty("fullname")]
        public string FullName { get; set; }

        /// <summary>
        /// <param name="ShortName">Short name of the course.</param> 
        /// </summary>
        [Required]
        [JsonProperty("shortname")]
        public string ShortName { get; set; }

        /// <summary>
        /// <param name="CategoryId">Category ID of the course.</param> 
        /// </summary>
        [Required]
        [JsonProperty("categoryid")]
        public int CategoryId { get; set; }

        /// <summary>
        /// <param name="CategoryId">Id number of the course. Optional.</param> 
        /// </summary>

        [JsonProperty("idnumber")]
        public string IdNumber { get; set; }

        /// <summary>
        /// <param name="Summary">Summary of the course. Optional.</param> 
        /// </summary>
        [JsonProperty("summary")]
        public string Summary { get; set; }

        /// <summary>
        /// <param name="SummaryFormat">SummaryFormat of the course. (1 = HTML, 0 = MOODLE, 2 = PLAIN or 4 = MARKDOWN). DEFAULT = 1</param> 
        /// </summary>
        [JsonProperty("summaryformat")]
        public int SummaryFormat { get; set; }

        /// <summary>
        /// <param name="Format">Format of the course. (weeks, topics, social, site). DEFAULT is topics</param> 
        /// </summary>
        [JsonProperty("format")]
        public string Format { get; set; }

        /// <summary>
        /// <param name="ShowGrades">1 if grades are shown, otherwise 0. DEFAULT is 1</param> 
        /// </summary>
        [JsonProperty("showgrades")]
        public int ShowGrades { get; set; }


        /// <summary>
        /// <param name="NewsItems">Number of recent items appearing on the course page. DEFAULT is 5</param> 
        /// </summary>
        [JsonProperty("newsitems")]
        public int NewsItems { get; set; }

        /// <summary>
        /// <param name="StartDate">Timestamp when the course start. Optional.</param> 
        /// </summary>
        [JsonProperty("startdate")]
        public int? StartDate { get; set; }

        /// <summary>
        /// <param name="EndDate">timestamp when the course end. Optional.</param> 
        /// </summary>
        [JsonProperty("enddate")]
        public int? EndDate { get; set; }

        /// <summary>
        /// <param name="NumSections"> (Deprecated, use courseformatoptions) number of weeks/topics.</param> 
        /// </summary>
        [JsonProperty("numsections")]
        public int? NumSections { get; set; }

        /// <summary>
        /// <param name="Maxbytes"> Largest size of file that can be uploaded into the course. DEFAULT is 0</param> 
        /// </summary>
        [JsonProperty("maxbytes")]
        public int Maxbytes { get; set; }

        /// <summary>
        /// <param name="ShowReports"> Are activity report shown (yes = 1, no =0). DEFAULT is 0</param> 
        /// </summary>
        [JsonProperty("showreports")]
        public int ShowReports { get; set; }

        /// <summary>
        /// <param name="Visible"> 1: available to student, 0: not available. Optional.</param> 
        /// </summary>
        [JsonProperty("visible")]
        public int? Visible { get; set; }

        /// <summary>
        /// <param name="HiddenSections"> (Deprecated, use courseformatoptions) How the hidden sections in the course are displayed to students. Optional.</param> 
        /// </summary>
        [JsonProperty("hiddensections")]
        public int? HiddenSections { get; set; }

        /// <summary>
        /// <param name="GroupMode"> no group, separate, visible. DEFAULT is 0.</param> 
        /// </summary>
        [JsonProperty("groupmode")]
        public int GroupMode { get; set; }

        /// <summary>
        /// <param name="GroupModeForce"> 1: yes, 0: no. DEFAULT is 0.</param> 
        /// </summary>
        [JsonProperty("groupmodeforce")]
        public int GroupModeForce { get; set; }

        /// <summary>
        /// <param name="DefaultGroupingId"> Default grouping id. DEFAULT is 0 </param> 
        /// </summary>
        [JsonProperty("defaultgroupingid")]
        public int DefaultGroupingId { get; set; }

        /// <summary>
        /// <param name="EnableCompletion"> Enabled, control via completion and activity settings. Disabled, not shown in activity settings. Optional. </param> 
        /// </summary>
        [JsonProperty("enablecompletion")]
        public int? EnableCompletion { get; set; }

        /// <summary>
        /// <param name="CompletionNotify"> 1: yes 0: no. Optional. </param> 
        /// </summary>
        [JsonProperty("completionnotify")]
        public int? CompletionNotify { get; set; }

        /// <summary>
        /// <param name="Lang"> Forced course language. Optional. </param> 
        /// </summary>
        [JsonProperty("lang")]
        public string Lang { get; set; }

        /// <summary>
        /// <param name="ForceTheme"> Name of the force theme. Optional. </param> 
        /// </summary>
        [JsonProperty("forcetheme")]
        public string ForceTheme { get; set; }


        /// <summary>
        /// <param name="CourseFormatOptions"> Additional options for particular course format. Optional. </param> 
        /// </summary>
        [JsonProperty("courseformatoptions")]
        ICollection<CourseFormatOption> CourseFormatOptions { get; set; }
    }


    //core_course_create_courses
    public class CreateCourseRequest : MoodleRequest
    {
        /// <summary>
        /// <param name="Courses"> List of courses to add.</param> 
        /// </summary>
        [Required]
        [JsonProperty("courses")]
        public ICollection<Course> Courses { get; set; }

        public override string Function => "core_course_create_courses";

        public void AddSingleCourse(Course course)
        {
            if (Courses == null)
                Courses = new List<Course>();
            Courses.Add(course);
        }
    }
}
