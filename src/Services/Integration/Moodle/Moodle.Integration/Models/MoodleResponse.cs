using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Moodle.Integration.Models
{
    public class MoodleResponse<TResponse> where TResponse: class
    {
        public bool Succeed { get; }

        public TResponse ResponseData { get; set; }

        public MoodleException MoodleException { get; set; }

        public string ErrorMessage { get; set; }

        public MoodleResponse(bool succeed)
        {
            Succeed = succeed;
        }
    }
}