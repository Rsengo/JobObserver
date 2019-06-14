using Resumes.Db.Dto.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resumes.Export.ModelBuilders
{
    public interface IResumeExportModelBuilder
    {
        IDictionary<string, string> Build(DtoResume resume);
    }
}
