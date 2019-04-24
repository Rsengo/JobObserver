using IdentityServer4.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.API.ViewModels
{
    public class ConsentViewModel : ConsentInputViewModel
    {
        public ConsentViewModel(
            ConsentInputViewModel model, 
            string returnUrl, 
            AuthorizationRequest request, 
            Client client, 
            Resources resources)
        {
            RememberConsent = model?.RememberConsent ?? true;
            ScopesConsented = model?.ScopesConsented ?? Enumerable.Empty<string>();

            ReturnUrl = returnUrl;

            ClientName = client.ClientName;
            ClientUrl = client.ClientUri;
            ClientLogoUrl = client.LogoUri;
            AllowRememberConsent = client.AllowRememberConsent;

            IdentityScopes = resources.IdentityResources.Select(x => new ScopeViewModel(x, ScopesConsented.Contains(x.Name) || model == null)).ToArray();
            ResourceScopes = resources.ApiResources.SelectMany(x => x.Scopes).Select(x => new ScopeViewModel(x, ScopesConsented.Contains(x.Name) || model == null)).ToArray();
        }

        [JsonProperty("client_name")]
        public string ClientName { get; set; }

        [JsonProperty("client_url")]
        public string ClientUrl { get; set; }

        [JsonProperty("client_logo_url")]
        public string ClientLogoUrl { get; set; }

        [JsonProperty("allow_remember_consent")]
        public bool AllowRememberConsent { get; set; }

        [JsonProperty("identity_scopes")]
        public IEnumerable<ScopeViewModel> IdentityScopes { get; set; }

        [JsonProperty("resource_scopes")]
        public IEnumerable<ScopeViewModel> ResourceScopes { get; set; }
    }

    public class ScopeViewModel
    {
        public ScopeViewModel(Scope scope, bool check)
        {
            Name = scope.Name;
            DisplayName = scope.DisplayName;
            Description = scope.Description;
            Emphasize = scope.Emphasize;
            Required = scope.Required;
            Checked = check || scope.Required;
        }

        public ScopeViewModel(IdentityResource identity, bool check)
        {
            Name = identity.Name;
            DisplayName = identity.DisplayName;
            Description = identity.Description;
            Emphasize = identity.Emphasize;
            Required = identity.Required;
            Checked = check || identity.Required;
        }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("display_scopes")]
        public string DisplayName { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("emphasize")]
        public bool Emphasize { get; set; }

        [JsonProperty("required")]
        public bool Required { get; set; }

        [JsonProperty("checked")]
        public bool Checked { get; set; }
    }
}
