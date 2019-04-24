using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.API.ViewModels
{
    public class ConsentInputViewModel
    {
        [JsonProperty("yes_button_clicked")]
        public bool? YesButtonClicked { get; set; }

        [JsonProperty("scopes_consented")]
        public IEnumerable<string> ScopesConsented { get; set; }

        [JsonProperty("remember_consent")]
        public bool RememberConsent { get; set; }

        [JsonProperty("return_url")]
        public string ReturnUrl { get; set; }
    }
}
