using System;
using System.Collections.Generic;
using System.Text;
using Moodle.Integration.Models;

namespace Moodle.Integration.Factories
{
    public class MoodleRequestFactory : IMoodleRequestFactory
    {
        private readonly string _token;

        private readonly string _restFormat;

        public MoodleRequestFactory(string token, string restFormat)
        {
            _token = token;
            _restFormat = restFormat;
        }

        public T Create<T>() where T : MoodleRequest, new()
        {
            var instance = new T
            {
                Token = _token,
                RestFormat = _restFormat
            };

            return instance;
        }
    }
}
