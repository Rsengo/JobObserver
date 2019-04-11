using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;

namespace Login.API.Configuration
{
    public static class Config
    {
        // ApiResources define the apis in your system
        public static IEnumerable<ApiResource> GetApis()
        {
            yield return new ApiResource("brandedtemplates", "Branded Templates Service");
            yield return new ApiResource("careerdays", "Career Days Service");
            yield return new ApiResource("educationalinstitutions", "Educational Institutions Service");
            yield return new ApiResource("employers", "Employers Service");
            yield return new ApiResource("paidservices", "Paid Services Shopping Aggregator");
            yield return new ApiResource("resumes", "Resumes Service");
            yield return new ApiResource("vacancies", "Vacancies Service");
            yield return new ApiResource("dictionaries", "Dictionaries Service");
            yield return new ApiResource("moodle", "Moodle Service");
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
