using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacancies.API.Services;
using Vacancies.Db.Dto.Models;
using Vacancies.Export;

namespace Vacancies.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class ExportController : ControllerBase
    {
        private readonly VacancyExportTaskStorage _storage;

        private readonly VacancyService _resumeService;

        private readonly IVacancyExporter _exporter;

        public ExportController(
            VacancyExportTaskStorage storage,
            VacancyService resumeService,
            IVacancyExporter exporter)
        {
            _storage = storage;
            _resumeService = resumeService;
            _exporter = exporter;
        }

        [HttpGet("vacancy/{id}")]
        public async Task<IActionResult> StartExport([FromRoute] long id)
        {
            var vacancy = await _resumeService.GetAsync(id);
            var dto = Mapper.Map<DtoVacancy>(vacancy);

            var task = _exporter.ExportAsync(dto);
            await task;

            var guid = _storage.RegisterTask(task);

            return Ok(guid);
        }

        [HttpGet("download/{guid}")]
        public async Task<IActionResult> StartExport([FromRoute] Guid guid)
        {
            var hasTask = _storage.TryGetTask(guid, out var task);

            if (!hasTask)
                return BadRequest("Задача экспорта не найдена");

            var stream = await task;

            return File(stream, "application/pdf", $"vacancy_{guid.ToString("D")}.pdf");
        }
    }
}
