using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.API
{
    public class RedirectSettings
    {
        public string IdentityServiceUrl { get; set; }

        public string LoginPageUrl { get; set; }

        public string RegistrationPageUrl { get; set; }

        public string WebAppClient { get; set; }

        public string FullLoginPageUrl => IdentityServiceUrl + LoginPageUrl;

        public string FullRegistrationPageUrl => IdentityServiceUrl + RegistrationPageUrl;
    }
}
