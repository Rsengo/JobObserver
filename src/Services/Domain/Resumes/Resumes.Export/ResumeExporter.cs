using jsreport.AspNetCore;
using jsreport.Shared;
using jsreport.Types;
using RazorLight;
using Resumes.Db.Dto.Models;
using Resumes.Db.Dto.Models.Applicants;
using Resumes.Export.ModelBuilders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resumes.Export
{
    public class ResumeExporter : IResumeExporter
    {
        private readonly IJsReportMVCService _reportMVCService;

        private readonly IRazorLightEngine _engine;

        private readonly IResumeExportModelBuilder _modelBuilder;

        private readonly string _viewPath;

        public ResumeExporter(
            IJsReportMVCService reportService,
            IRazorLightEngine engine,
            IResumeExportModelBuilder modelBuilder,
            string viewPath)
        {
            _reportMVCService = reportService;
            _engine = engine;
            _modelBuilder = modelBuilder;
            _viewPath = viewPath;
        }

        public async Task<Stream> ExportAsync (DtoResume resume) {
            var dict = _modelBuilder.Build(resume);

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
