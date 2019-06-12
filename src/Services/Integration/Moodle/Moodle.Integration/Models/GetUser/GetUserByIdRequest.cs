using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Moodle.Integration.Models.GetUser
{
    //core_user_get_users
    public class GetUserByIdRequest : MoodleRequest
    {
        public override string Function => "core_user_get_users";

        /// <summary>
        /// <param name="Criterias"> Pairs of key\value to search </param>
        /// </summary>
        [Required]
        [JsonProperty("criteria")]
        public IImmutableList<Criteria> Criterias { get; }

        public GetUserByIdRequest(int id)
        {
            Criterias = new List<Criteria>
            {
                new Criteria(id)
            }.ToImmutableList();
        }
    }

    public class Criteria
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
        [Required]
        [JsonProperty("key")]
        public string Key { get => "id"; }

        /// <summary>
        /// <param name="Value"> Value of the key</param>
        /// </summary>
        [Required]
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
