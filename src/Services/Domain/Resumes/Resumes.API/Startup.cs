using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BuildingBlocks.Extensions.AutoMapper;
using BuildingBlocks.Extensions.EventBus.RabbitMQ;
using BuildingBlocks.Extensions.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Resumes.API.HttpFilters;
using Resumes.API.Security;
using Resumes.API.Security.Accessors;
using Resumes.API.Security.Events;
using Resumes.API.Security.Handlers.Applicant;
using Resumes.Db;
using Resumes.Db.Dto;
using Resumes.Db.Models;
using Resumes.Db.Synchronization.EventHandlers.Applicants;
using Resumes.Db.Synchronization.EventHandlers.Driving;
using Resumes.Db.Synchronization.EventHandlers.Educations;
using Resumes.Db.Synchronization.EventHandlers.Employments;
using Resumes.Db.Synchronization.EventHandlers.Geographic;
using Resumes.Db.Synchronization.EventHandlers.Geographic.Metro;
using Resumes.Db.Synchronization.EventHandlers.Industries;
using Resumes.Db.Synchronization.EventHandlers.Languages;
using Resumes.Db.Synchronization.EventHandlers.Negotiations;
using Resumes.Db.Synchronization.EventHandlers.Salaries;
using Resumes.Db.Synchronization.EventHandlers.Schedules;
using Resumes.Db.Synchronization.EventHandlers.Skills;
using Resumes.Db.Synchronization.EventHandlers.Specializations;
using Resumes.Db.Synchronization.EventHandlers.Statuses;
using Resumes.Db.Synchronization.EventHandlers.Travel;
using Resumes.Db.Synchronization.EventHandlers.Travel.Relocation;
using Resumes.Db.Synchronization.Events.Applicants;
using Resumes.Db.Synchronization.Events.Driving;
using Resumes.Db.Synchronization.Events.Educations;
using Resumes.Db.Synchronization.Events.Employments;
using Resumes.Db.Synchronization.Events.Geographic;
using Resumes.Db.Synchronization.Events.Geographic.Metro;
using Resumes.Db.Synchronization.Events.Industries;
using Resumes.Db.Synchronization.Events.Languages;
using Resumes.Db.Synchronization.Events.Negotiations;
using Resumes.Db.Synchronization.Events.Salaries;
using Resumes.Db.Synchronization.Events.Skills;
using Resumes.Db.Synchronization.Events.Specializations;
using Resumes.Db.Synchronization.Events.Statuses;
using Resumes.Db.Synchronization.Events.Travel;
using Resumes.Db.Synchronization.Events.Travel.Relocation;
using Swashbuckle.AspNetCore.Swagger;

namespace Resumes.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ResumesDbContext>(opt =>
            {
                opt.UseSqlServer(
                    Configuration["ConnectionString"],
                    sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(typeof(ResumesDbContext)
                            .GetTypeInfo()
                            .Assembly
                            .GetName()
                            .Name);
                        sqlOptions.EnableRetryOnFailure(
                            15,
                            TimeSpan.FromSeconds(30),
                            null);
                    });
            });

            services.AddAutoMapper(builder =>
            {
                builder.AddAssembly(typeof(AutoMapperBeacon).Assembly);
            });

            services.AddEventBusRabbitMQ(builder =>
            {
                var retryCount = int.Parse(Configuration["EventBusRetryCount"]);

                builder.ConfigureConnection(con =>
                {
                    con.HostName = Configuration["EventBusConnection"];
                    con.UserName = Configuration["EventBusUserName"];
                    con.Password = Configuration["EventBusPassword"];
                });

                builder.SubscriptionClientName = Configuration["SubscriptionClientName"];
                builder.RetryCount = retryCount;

                builder.RegisterEventHandler<ApplicantsChangedHandler>();
                builder.RegisterEventHandler<GendersChangedHandler>();
                builder.RegisterEventHandler<DrivingLicenseTypesChangedHandler>();
                builder.RegisterEventHandler<EducationalLevelsChangedHandler>();
                builder.RegisterEventHandler<EmploymentsChangedHandler>();
                builder.RegisterEventHandler<LinesChangedHandler>();
                builder.RegisterEventHandler<MetroChangedHandler>();
                builder.RegisterEventHandler<StationsChangedHandler>();
                builder.RegisterEventHandler<AreasChangedHandler>();
                builder.RegisterEventHandler<IndustriesChangedHandler>();
                builder.RegisterEventHandler<LanguageLevelsChangedHandler>();
                builder.RegisterEventHandler<LanguagesChangedHandler>();
                builder.RegisterEventHandler<ResponsesChangedHandler>();
                builder.RegisterEventHandler<CurrenciesChangedHandler>();
                builder.RegisterEventHandler<SchedulesChangedHandler>();
                builder.RegisterEventHandler<SkillsChangedHandler>();
                builder.RegisterEventHandler<SpecializationsChangedHandler>();
                builder.RegisterEventHandler<ResumeStatusesChangedHandler>();
                builder.RegisterEventHandler<RelocationTypesChangedHandler>();
                builder.RegisterEventHandler<BusinessTripReadinessChangedHandler>();
                builder.RegisterEventHandler<TravelTimesChangedHandler>();
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(Configuration["SwaggerDocName"],
                    new Info
                    {
                        Title = Configuration["SwaggerDocTitle"],
                        Version = Configuration["SwaggerDocVersion"]
                    });
            });

            services.AddCors(options =>
            {
                options.AddPolicy(Configuration["CorsPolicy"],
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            services.AddMvc(opt =>
            {
                opt.Filters.Add<HttpGlobalExceptionFilter>();
                opt.Filters.Add<ValidateModelStateFilter>();
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddAccessControl(builder =>
            {
                builder.UseAccessEventFactory<AccessEventFactoryMock>();
                builder.UseAccessorFactory<AccessorFactoryMock>();

                builder.AddAccessor<AdminAccessor>(paramsBuilder =>
                { }, (sp, dict) =>
                {
                    var accessor = new AdminAccessor(sp, dict);
                    return accessor;
                });

                builder.AddAccessor<ApplicantAccessor>(paramsBuilder =>
                {
                    paramsBuilder.RegisterHandler<ApplicantAccessEvent<Resume>, ApplicantResumeAccessHandler, Resume>();
                }, (sp, dict) =>
                {
                    var accessor = new ApplicantAccessor(sp, dict);
                    return accessor;
                });

                builder.AddAccessor<EmployerManagerAccessor>(paramsBuilder =>
                { }, (sp, dict) =>
                {
                    var accessor = new EmployerManagerAccessor(sp, dict);
                    return accessor;
                });

                builder.AddAccessor<EducationalInstitutionManagerAccessor>(paramsBuilder =>
                { }, (sp, dict) =>
                {
                    var accessor = new EducationalInstitutionManagerAccessor(sp, dict);
                    return accessor;
                });
            });

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.Authority = Configuration["IdentityUrl"];
                options.Audience = "resumes";
                options.RequireHttpsMetadata = false;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(Configuration["CorsPolicy"]);

            app.UseAuthentication();
            app.UseAccessControl();

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(
                    Configuration["SwaggerEndpointUrl"],
                    Configuration["SwaggerEndpointName"]);
            });

            //app.UseEventBusRabbitMQ(eventBus =>
            //{
            //     eventBus.Subscribe<ApplicantsChanged, ApplicantsChangedHandler>();
            //     eventBus.Subscribe<GendersChanged, GendersChangedHandler>();
            //     eventBus.Subscribe<DrivingLicenseTypesChanged, DrivingLicenseTypesChangedHandler>();
            //     eventBus.Subscribe<EducationalLevelsChanged, EducationalLevelsChangedHandler>();
            //     eventBus.Subscribe<EmploymentsChanged, EmploymentsChangedHandler>();
            //     eventBus.Subscribe<LinesChanged, LinesChangedHandler>();
            //     eventBus.Subscribe<MetroChanged, MetroChangedHandler>();
            //     eventBus.Subscribe<StationsChanged, StationsChangedHandler>();
            //     eventBus.Subscribe<AreasChanged, AreasChangedHandler>();
            //     eventBus.Subscribe<IndustriesChanged, IndustriesChangedHandler>();
            //     eventBus.Subscribe<LanguageLevelsChanged, LanguageLevelsChangedHandler>();
            //     eventBus.Subscribe<LanguagesChanged, LanguagesChangedHandler>();
            //     eventBus.Subscribe<ResponsesChanged, ResponsesChangedHandler>();
            //     eventBus.Subscribe<CurrenciesChanged, CurrenciesChangedHandler>();
            //     eventBus.Subscribe<SkillsChanged, SkillsChangedHandler>();
            //     eventBus.Subscribe<SpecializationsChanged, SpecializationsChangedHandler>();
            //     eventBus.Subscribe<ResumeStatusesChanged, ResumeStatusesChangedHandler>();
            //     eventBus.Subscribe<RelocationTypesChanged, RelocationTypesChangedHandler>();
            //     eventBus.Subscribe<BusinessTripReadinessChanged, BusinessTripReadinessChangedHandler>();
            //     eventBus.Subscribe<TravelTimesChanged, TravelTimesChangedHandler>();
            //});
        }
    }
}
