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
                RedirectUris = {
                    $"{clientsUrl["WebApp"]}/auth/",
                    //TODO тестовая фича
                    "http://localhost:8000/",
                    "http://localhost:8000/auth/"
                },
                RequireConsent = false,
                PostLogoutRedirectUris =
                {
                    $"{clientsUrl["WebApp"]}/",
                    //TODO тестовая фича
                    "http://localhost:8000/",
                    "http://localhost:8000/auth/"
                },
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

            yield return new Client
            {
                ClientId = "postman",
                ClientName = "Postman Client",
                AllowedGrantTypes = GrantTypes.Code,
                AllowAccessTokensViaBrowser = true,
                RedirectUris = {"https://www.getpostman.com/oauth2/callback/"},
                RequireConsent = false,
                PostLogoutRedirectUris = {"https://www.getpostman.com/oauth2/callback/"},
                AllowedCorsOrigins = {"https://www.getpostman.com/oauth2/callback/"},
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
                },
                ClientSecrets = new List<Secret> {new Secret("Secret".Sha256())},
                RequireClientSecret = false
            };
        }
    }
}
