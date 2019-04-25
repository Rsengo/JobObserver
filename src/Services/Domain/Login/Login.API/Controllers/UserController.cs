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

namespace Login.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        private readonly IEventBus _eventBus;

        public UserController(
            UserManager<User> userManager,
            IEventBus eventBus)
        {
            _userManager = userManager;
            _eventBus = eventBus;
        }

        private readonly LoginDbContext _context;

        public UserController(
            UserManager<User> userManager,
            LoginDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeUserInformation(DtoUser dto, string id)
        {
            var contactsId = dto.ContactsId;
            if (dto.Contacts != null)
            {
                contactsId = await UpdateContacts(dto, id);
            }

            var newUser = Mapper.Map<User>(dto);
            newUser.Id = id;
            newUser.ContactsId = contactsId;

            await _userManager.UpdateAsync(newUser);

            var response = Mapper.Map<DtoUser>(newUser);

            return Ok(response);
        }

        [HttpPost("restoreadmin")]
        public async Task<IActionResult> RestoreAdmin()
        {
            var user = await _userManager.FindByEmailAsync(IdentityConfig.ADMIN_EMAIL);
            var dto = Mapper.Map<DtoUser>(user);

            var @event = new ApplicantsChanged
            {
                Created = new[] {dto}
            };

            _eventBus.Publish(@event);

            return Ok();
        }

        private async Task<long> UpdateContacts(DtoUser dto, string id)
        {
            var contacts = Mapper.Map<Contact>(dto);

            if (dto.ContactsId != null)
            {
                contacts.Id = dto.ContactsId.Value;
            }

            await _context.BulkMergeAsync(new[] { contacts });

            var phones = contacts.Phones;
            var sites = contacts.Sites;

            foreach (var phone in phones)
            {
                phone.ContactId = contacts.Id;
            }

            foreach (var site in sites)
            {
                site.ContactId = contacts.Id;
            }

            await _context.BulkMergeAsync(new[] { phones });
            await _context.BulkMergeAsync(new[] { sites });

            return contacts.Id;
        }
    }
}
