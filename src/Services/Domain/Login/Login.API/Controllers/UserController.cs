using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlocks.EventBus.Abstractions;
using Login.API.Configuration;
using Login.Db.Dto.Models;
using Login.Db.Models;
using Login.Db.Synchronization.Events.Users;
using Login.Db;
using Login.Db.Models.Contacts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Login.Db.Dto.Models.Contacts;
using Login.API.Data;
using IdentityModel;
using Microsoft.EntityFrameworkCore;

namespace Login.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        private readonly IEventBus _eventBus;

        private readonly LoginDbContextSeed _seeder;

        private readonly LoginDbContext _context;

        public UserController(
            UserManager<User> userManager,
            IEventBus eventBus,
            LoginDbContext context,
            LoginDbContextSeed seeder)
        {
            _userManager = userManager;
            _eventBus = eventBus;
            _context = context;
            _seeder = seeder;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeUserInformation([FromBody]DtoUser dto, [FromQuery]string id)
        {
            var newUser = Mapper.Map<User>(dto);
            newUser.Id = id;

            await _userManager.UpdateAsync(newUser);

            var response = Mapper.Map<DtoUser>(newUser);

            return Ok(response);
        }

        [HttpGet("getFullUserInfo")]
        public async Task<IActionResult> GetFullUserInfo()
        {
            var id = HttpContext.User.Claims
                .First(x => x.Type == JwtClaimTypes.Subject)
                .Value;

            var user = await _context.Users
                .Include(x => x.Gender)
                .Include(x => x.Contacts)
                    .ThenInclude(x => x.Phones)
                .Include(x => x.EducationalInstitutionManagerAttributes)
                .Include(x => x.EmployerManagerAttributes)
                .SingleAsync(x => x.Id == id);

            await _context.Areas.LoadAsync();

            var contactId = user.Contacts.Id;
            await _context.Sites
                .Where(x => x.ContactId == contactId)
                .Include(x => x.Type)
                .LoadAsync();

            var dtoUser = Mapper.Map<DtoUser>(user);

            return Ok(dtoUser);
        }

        [HttpPost("_restoreadmin")]
        public async Task<IActionResult> RestoreAdmin()
        {
            var user = await _seeder.SeedAsync();
            var dto = Mapper.Map<DtoUser>(user);

            var @event = new ApplicantsChanged
            {
                Created = new[] {dto}
            };

            _eventBus.Publish(@event);

            return Ok();
        }
    }
}
