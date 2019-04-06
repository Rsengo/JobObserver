using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moodle.Integration.Factories;
using Moodle.Integration.Models;
using Newtonsoft.Json;

namespace Moodle.Integration
{
    public class MoodleIntegrator : IMoodleIntegrator, IDisposable
    {
        private readonly HttpClient _httpClient;

        private readonly ILogger<IMoodleIntegrator> _logger;

        public string MoodleRestUrl { get; }

        public IMoodleRequestFactory RequestFactory { get; }

        public MoodleIntegrator(
            IMoodleRequestFactory requestFactory, 
            ILogger<IMoodleIntegrator> logger, 
            string moodleRestUrl)
        {
            _httpClient = CreateHttpClient(moodleRestUrl);
            _logger = logger;
            MoodleRestUrl = moodleRestUrl;
            RequestFactory = requestFactory;
        }

        public async Task<MoodleResponse<TResponse>> SendRequestAsync<TRequest, TResponse>(TRequest request) 
            where TRequest : MoodleRequest 
            where TResponse : class
        {
            var httpResponse = await SendRequestAndGetResponseAsync(request);
            var responseString = await httpResponse.Content.ReadAsStringAsync();

            try
            {
                return DeserializeResponse<TResponse>(responseString);
            }
            catch (JsonException)
            {
                return DeserializeError<TResponse>(responseString);
            }
        }

        public Task<HttpResponseMessage> SendRequestAndGetResponseAsync<TRequest>(TRequest request)
            where TRequest : MoodleRequest
        {
            var jsonData = JsonConvert.SerializeObject(request);
            var data = new StringContent(jsonData);

            return _httpClient.PostAsync(string.Empty, data);
        }

        private MoodleResponse<TResponse> DeserializeError<TResponse>(string responseString)
            where TResponse : class
        {
            try
            {
                var moodleEx = JsonConvert.DeserializeObject<MoodleException>(responseString);

                _logger.LogError("Moodle Web Service Call Failed; {@moodleEx}", moodleEx);

                var result = new MoodleResponse<TResponse>(false)
                {
                    MoodleException = moodleEx,
                    ErrorMessage = moodleEx.Message
                };

                return result;
            }
            catch (JsonException)
            {
                const string errorMessage = "Moodle Web Service Call Failed; " +
                                            "MoodleIntegrator::GetMoodleData - couldn't deserialize response";
                _logger.LogError(errorMessage);

                var result = new MoodleResponse<TResponse>(false)
                {
                    ErrorMessage = errorMessage
                };

                return result;
            }
        }

        private MoodleResponse<TResponse> DeserializeResponse<TResponse>(string responseString)
            where TResponse : class
        {
            var settings = new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            var response = JsonConvert.DeserializeObject<TResponse>(responseString, settings);

            var result = new MoodleResponse<TResponse>(true)
            {
                ResponseData = response
            };

            return result;
        }

        private static HttpClient CreateHttpClient(string restUrl)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(restUrl)
            };

            return client;
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}
