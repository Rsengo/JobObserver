using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moodle.API.Controllers
{
    public class CoursesController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create()
        {
            throw new NotImplementedException();
        }

        [HttpPost("subscribe")]
        public async Task<IActionResult> Subscribe()
        {
            throw new NotImplementedException();
        }
    }
}
