using System;
using System.Collections.Generic;
using System.Text;

namespace Moodle.Integration.Models
{
    public abstract class MoodleRequest
    {
        public string Token { get; set; }

        public string Function { get; set; }

        public string RestFormat { get; set; }
    }
}
