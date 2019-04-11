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
        IMoodleRequestFactory RequestFactory { get; }

        Task<MoodleResponse<TResponse>> SendRequestAsync<TRequest, TResponse>(TRequest request)
            where TRequest : MoodleRequest
            where TResponse : class;
    }
}
