using jsreport.Types;
using Resumes.Db.Dto.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Resumes.Export
{
    public interface IResumeExporter
    {
        Task<Stream> ExportAsync(DtoResume resume);
    }
}
