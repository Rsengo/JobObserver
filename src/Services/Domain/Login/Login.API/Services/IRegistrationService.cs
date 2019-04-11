using System;
using System.Threading.Tasks;
using Login.API.Configuration;
using Login.API.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Login.API.Services
{
    public interface IRegistrationService
    {
        event Action<IdentityResult> OnErrorsOccured;

        Task RegisterAsync(RegistrationViewModel model, string role);
    }
}
