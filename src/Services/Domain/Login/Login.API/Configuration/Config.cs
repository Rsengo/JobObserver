using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.Models;

namespace Login.API.Configuration
{
    public static class Config
    {
        // ApiResources define the apis in your system
        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                new ApiResource("brandedtemplates", "Branded Templates Service"),
                new ApiResource("careerdays", "Career Days Service"),
                new ApiResource("educationalinstitutions", "Educational Institutions Service"),
                new ApiResource("employers", "Employers Service"),
                new ApiResource("paidservices", "Paid Services Shopping Aggregator"),
                new ApiResource("resumes", "Resumes Service"),
                new ApiResource("vacancies", "Vacancies Service"),
                new ApiResource("dictionaries", "Dictionaries Service"),
                new ApiResource("moodle", "Moodle Service")
            };
        }

        public static IEnumerable<IdentityResource> GetResources()
        {
            yield return new IdentityResources.OpenId();
            yield return new IdentityResources.Profile();
        }

        // client want to access resources (aka scopes)
        public static IEnumerable<Client> GetClients(Dictionary<string, string> clientsUrl)
        {
            yield return new Client
            {
                ClientId = "web_app",
                ClientName = "Job Observer Web App Client",
                AllowedGrantTypes = GrantTypes.Implicit,
                AllowAccessTokensViaBrowser = true,
                RedirectUris = {$"{clientsUrl["WebApp"]}/"},
                RequireConsent = false,
                PostLogoutRedirectUris = {$"{clientsUrl["WebApp"]}/"},
                AllowedCorsOrigins = {$"{clientsUrl["WebApp"]}"},
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "brandedtemplates", 
                    "careerdays", 
                    "educationalinstitutions", 
                    "employers", 
                    "paidservices", 
                    "resumes", 
                    "vacancies", 
                    "dictionaries", 
                    "moodle"
                }
            };
        }
    }
}
