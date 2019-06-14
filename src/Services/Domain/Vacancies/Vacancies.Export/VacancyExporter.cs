using jsreport.AspNetCore;
using jsreport.Types;
using RazorLight;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vacancies.Db.Dto.Models;
using Vacancies.Export.ModelBuilders;

namespace Vacancies.Export
{
    public class VacancyExporter : IVacancyExporter
    {
        private readonly IJsReportMVCService _reportMVCService;

        private readonly IRazorLightEngine _engine;

        private readonly IVacancyExportModelBuilder _modelBuilder;

        private readonly string _viewPath;

        public VacancyExporter(
            IJsReportMVCService reportService,
            IRazorLightEngine engine,
            IVacancyExportModelBuilder modelBuilder,
            string viewPath)
        {
            _reportMVCService = reportService;
            _engine = engine;
            _modelBuilder = modelBuilder;
            _viewPath = viewPath;
        }

        public async Task<Stream> ExportAsync(DtoVacancy vacancy)
        {
            var dict = _modelBuilder.Build(vacancy);

            var result = await _engine.CompileRenderAsync(_viewPath, dict);

            var report = await _reportMVCService.RenderAsync(new RenderRequest()
            {
                Template = new Template
                {
                    Content = result,
                    Engine = Engine.None,
                    Recipe = Recipe.ChromePdf
                }
            });

            return report.Content;
        }
    }
}
