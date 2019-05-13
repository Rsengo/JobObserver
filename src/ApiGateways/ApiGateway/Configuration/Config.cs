using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGateway.Configuration
{
    public static class Config
    {
        public static IEnumerable<string> GetValidAudience()
        {
            yield return "brandedtemplates";
            yield return "careerdays";
            yield return "educationalinstitutions";
            yield return "employers";
            yield return "paidservices";
            yield return "resumes";
            yield return "vacancies";
            yield return "dictionaries";
            yield return "moodle";
        }
    }
}
