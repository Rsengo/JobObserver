using System;
using System.Collections.Generic;
using System.Text;
using Moodle.Integration.Models;

namespace Moodle.Integration.Factories
{
    public interface IMoodleRequestFactory
    {
        T Create<T>() where T : MoodleRequest, new();
    }
}
