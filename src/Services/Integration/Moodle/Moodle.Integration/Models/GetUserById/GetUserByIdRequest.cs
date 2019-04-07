using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moodle.Integration.Models.GetUserById
{
    class Criteria
    {
        public Criteria()
        {

        }

        public Criteria(int id)
        {
            Value = id.ToString();
        }

        /// <summary>
        /// <param name="Key"> id, lastname, firstname, idnumber, username, username, email, or auth </param>
        /// </summary>
        [JsonProperty("key")]
        public string Key { get => "id"; }

        /// <summary>
        /// <param name="Value"> Value </param>
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }
    }

    class GetUserByIdRequest : MoodleRequest
    {
        public GetUserByIdRequest(int id)
        {
            Criterias = new List<Criteria>
            {
                new Criteria(id)
            };
        }

        /// <summary>
        /// <param name="Criterias"> Pairs of key\value to search </param>
        /// </summary>
        [JsonProperty("criteria")]
        public ICollection<Criteria> Criterias;
    }
}
