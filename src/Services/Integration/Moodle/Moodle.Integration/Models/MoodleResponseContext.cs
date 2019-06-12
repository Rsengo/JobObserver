using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Moodle.Integration.Models
{
    public class MoodleResponseContext<TResponse> where TResponse: class
    {
        public bool Succeed { get; }

        public TResponse ResponseData { get; set; }

        public Exception Exception { get; set; }

        public MoodleResponseContext(bool succeed)
        {
            Succeed = succeed;
        }
    }
}