using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moodle.Integration.Factories;
using Moodle.Integration.Models;

namespace Moodle.Integration
{
    public interface IMoodleIntegrator
    {
        Task<MoodleResponseContext<TResponse>> SendRequestAsync<TResponse>(MoodleRequest request)
            where TResponse : class;
    }
}
