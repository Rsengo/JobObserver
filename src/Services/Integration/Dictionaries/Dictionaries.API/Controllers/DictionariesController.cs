using Microsoft.AspNetCore.Mvc;

namespace Dictionaries.API.Controllers
{
    using System.Threading.Tasks;

    using Dictionaries.API.Infrastructure.Initialization;

    [Route("api/v1/[controller]")]
    public class DictionariesController : ControllerBase
    {
        private readonly DictionariesInitializationService _initializationService;

        public DictionariesController(DictionariesInitializationService initializationService)
        {
            _initializationService = initializationService;
        }

        [HttpPost("initialize")]
        public async Task<IActionResult> InitializeAll()
        {
            await _initializationService.InitializeAsync();
            return Ok();
        }
    }
}