using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Login.API.Configuration;
using Login.API.Infrastructure.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Login.API.Infrastructure.Services
{
    public interface IRegistrationService
    {
        event Action<IdentityResult> OnErrorsOccured;

        Task RegisterAsync(RegistrationViewModel model, DefaultRole role);
    }
}
