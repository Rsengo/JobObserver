using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace Moodle.Integration.Models.GetUser
{
    public class GetUserByUsernameRequest : MoodleRequest
    {
        public override string Function => "core_user_get_users_by_field";

        [JsonProperty("field")]
        public string Field => "username";


        [JsonProperty("values")]
        public IImmutableList<string> Values;

        public GetUserByUsernameRequest(string username)
        {
            Values = new List<string>()
            {
                username
            }.ToImmutableList();
        }
    }
}
