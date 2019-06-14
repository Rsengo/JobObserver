using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Resumes.API.Services;
using Resumes.Db.Dto.Models;
using Resumes.Export;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resumes.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class ExportController: ControllerBase
    {
        private readonly ResumeExportTaskStorage _storage;

        private readonly ResumeService _resumeService;

        private readonly IResumeExporter _exporter;

        public ExportController(
            ResumeExportTaskStorage storage, 
            ResumeService resumeService, 
            IResumeExporter exporter)
        {
            _storage = storage;
            _resumeService = resumeService;
            _exporter = exporter;
        }

        [HttpGet("resume/{id}")]
        public async Task<IActionResult> StartExport([FromRoute] long id)
        {
            var resume = await _resumeService.GetAsync(id);
            var dto = Mapper.Map<DtoResume>(resume);

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

            return File(stream, "application/pdf", $"resume_{guid.ToString("D")}.pdf");
        }
    }
}
