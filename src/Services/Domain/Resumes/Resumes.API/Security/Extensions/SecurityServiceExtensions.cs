using BuildingBlocks.Extensions.Security;
using BuildingBlocks.Extensions.Security.Builders;
using Microsoft.Extensions.DependencyInjection;
using Resumes.API.Security.Accessors;
using Resumes.API.Security.Events;
using Resumes.API.Security.Handlers.Applicant;
using Resumes.API.Security.Handlers.Employer;
using Resumes.Db.Models;
using Resumes.Db.Models.Negotiations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resumes.API.Security.Extensions
{
    public static class SecurityServiceExtensions
    {
        public static IServiceCollection AddAccessControl(this IServiceCollection services)
        {
            services.AddAccessControl(builder =>
            {
                builder.UseAccessEventFactory<AccessEventFactoryMock>();
                builder.UseAccessorFactory<AccessorFactoryMock>();

                builder
                    .AddAdminAccessControl()
                    .AddApplicantAccessControl()
                    .AddEducationalInstitutionAccessControl()
                    .AddEmployerAccessControl();
            });

            return services;
        }

        private static SecurityAccessorBuilder AddAdminAccessControl(this SecurityAccessorBuilder builder)
        {
            builder.AddAccessor<AdminAccessor>(paramsBuilder =>
            { }, (sp, dict) =>
            {
                var accessor = new AdminAccessor(sp, dict);
                return accessor;
            });

            return builder;
        }

        private static SecurityAccessorBuilder AddApplicantAccessControl(this SecurityAccessorBuilder builder)
        {
            builder.AddAccessor<ApplicantAccessor>(paramsBuilder =>
            {
                paramsBuilder.RegisterHandler<ApplicantAccessEvent<Resume>, ApplicantResumeAccessHandler, Resume>();
            }, (sp, dict) =>
            {
                var accessor = new ApplicantAccessor(sp, dict);
                return accessor;
            });

            return builder;
        }

        private static SecurityAccessorBuilder AddEmployerAccessControl(
            this SecurityAccessorBuilder builder)
        {
            builder.AddAccessor<EmployerManagerAccessor>(paramsBuilder =>
            {
                paramsBuilder.RegisterHandler<
                    EmployerAccessEvent<ResumeNegotiation>,
                    EmployerNegotiationAccessHandler,
                    ResumeNegotiation>();
            }, (sp, dict) =>
            {
                var accessor = new EmployerManagerAccessor(sp, dict);
                return accessor;
            });

            return builder;
        }

        private static SecurityAccessorBuilder AddEducationalInstitutionAccessControl(
            this SecurityAccessorBuilder builder)
        {
            builder.AddAccessor<EducationalInstitutionManagerAccessor>(paramsBuilder =>
            { }, (sp, dict) =>
            {
                var accessor = new EducationalInstitutionManagerAccessor(sp, dict);
                return accessor;
            });

            return builder;
        }
    }
}
