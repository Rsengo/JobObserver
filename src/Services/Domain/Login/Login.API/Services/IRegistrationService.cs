using System;
using System.Threading.Tasks;
using Login.API.Configuration;
using Login.API.ViewModels;
using Login.Db.Models;
using Microsoft.AspNetCore.Identity;

namespace Login.API.Services
{
    public interface IRegistrationService
    {
        event Action<IdentityResult> OnErrorsOccured;

        Task<User> RegisterAsync(RegistrationViewModel model, string role);
    }
}
