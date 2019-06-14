<<<<<<< HEAD
﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Reflection;
using BuildingBlocks.Extensions.AutoMapper;
using BuildingBlocks.Extensions.EventBus.RabbitMQ;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Vacancies.API.HttpFilters;
using Vacancies.Db;
using Vacancies.Db.Dto;
using Vacancies.Db.Synchronization.EventHandlers.Driving;
using Vacancies.Db.Synchronization.EventHandlers.Employers;
using Vacancies.Db.Synchronization.EventHandlers.Employments;
using Vacancies.Db.Synchronization.EventHandlers.Geographic;
using Vacancies.Db.Synchronization.EventHandlers.Geographic.Metro;
using Vacancies.Db.Synchronization.EventHandlers.Industries;
using Vacancies.Db.Synchronization.EventHandlers.Languages;
using Vacancies.Db.Synchronization.EventHandlers.Negotiations;
using Vacancies.Db.Synchronization.EventHandlers.Salaries;
using Vacancies.Db.Synchronization.EventHandlers.Schedules;
using Vacancies.Db.Synchronization.EventHandlers.Skills;
using Vacancies.Db.Synchronization.EventHandlers.Specializations;
using Vacancies.Db.Synchronization.EventHandlers.Statuses;
using Vacancies.Db.Synchronization.Events.Driving;
using Vacancies.Db.Synchronization.Events.Employers;
using Vacancies.Db.Synchronization.Events.Employments;
using Vacancies.Db.Synchronization.Events.Geographic;
using Vacancies.Db.Synchronization.Events.Geographic.Metro;
using Vacancies.Db.Synchronization.Events.Industries;
using Vacancies.Db.Synchronization.Events.Languages;
using Vacancies.Db.Synchronization.Events.Negotiations;
using Vacancies.Db.Synchronization.Events.Salaries;
using Vacancies.Db.Synchronization.Events.Schedules;
using Vacancies.Db.Synchronization.Events.Skills;
using Vacancies.Db.Synchronization.Events.Specializations;
using Vacancies.Db.Synchronization.Events.Statuses;

namespace Vacancies.API
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
            services.AddDbContext<VacanciesDbContext>(opt =>
            {
                opt.UseSqlServer(
                    Configuration["ConnectionString"],
                    sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(typeof(VacanciesDbContext)
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

                builder.SubscriptionClientName = Configuration["EventBusSubscriptionClientName"];
                builder.RetryCount = retryCount;

                builder.RegisterEventHandler<DrivingLicenseTypesChangedHandler>();
                builder.RegisterEventHandler<EmployersChangedHandler>();
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
                builder.RegisterEventHandler<VacancyStatusesChangedHandler>();
                builder.RegisterEventHandler<SpecializationsChangedHandler>();
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

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.Authority = Configuration["IdentityUrl"];
                options.Audience = "vacancies";
                options.RequireHttpsMetadata = false;
                options.BackchannelHttpHandler = new HttpClientHandler { ServerCertificateCustomValidationCallback = delegate { return true; } };
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

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(
                    Configuration["SwaggerEndpointUrl"],
                    Configuration["SwaggerEndpointName"]);
            });

            app.UseEventBusRabbitMQ(eventBus =>
            {
                eventBus.Subscribe<DrivingLicenseTypesChanged, DrivingLicenseTypesChangedHandler>();
                eventBus.Subscribe<EmployersChanged, EmployersChangedHandler>();
                eventBus.Subscribe<EmploymentsChanged, EmploymentsChangedHandler>();
                eventBus.Subscribe<LinesChanged, LinesChangedHandler>();
                eventBus.Subscribe<MetroChanged, MetroChangedHandler>();
                eventBus.Subscribe<StationsChanged, StationsChangedHandler>();
                eventBus.Subscribe<AreasChanged, AreasChangedHandler>();
                eventBus.Subscribe<IndustriesChanged, IndustriesChangedHandler>();
                eventBus.Subscribe<LanguageLevelsChanged, LanguageLevelsChangedHandler>();
                eventBus.Subscribe<LanguagesChanged, LanguagesChangedHandler>();
                eventBus.Subscribe<ResponsesChanged, ResponsesChangedHandler>();
                eventBus.Subscribe<CurrenciesChanged, CurrenciesChangedHandler>();
                eventBus.Subscribe<SchedulesChanged, SchedulesChangedHandler>();
                eventBus.Subscribe<SkillsChanged, SkillsChangedHandler>();
                eventBus.Subscribe<VacancyStatusesChanged, VacancyStatusesChangedHandler>();
                eventBus.Subscribe<SpecializationsChanged, SpecializationsChangedHandler>();
            });
        }
    }
}
=======
﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Reflection;
using BuildingBlocks.Extensions.AutoMapper;
using BuildingBlocks.Extensions.EventBus.RabbitMQ;
using jsreport.AspNetCore;
using jsreport.Binary;
using jsreport.Client;
using jsreport.Local;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RazorLight;
using Swashbuckle.AspNetCore.Swagger;
using Vacancies.API.HttpFilters;
using Vacancies.API.Services;
using Vacancies.Db;
using Vacancies.Db.Dto;
using Vacancies.Db.Synchronization.EventHandlers.Driving;
using Vacancies.Db.Synchronization.EventHandlers.Employers;
using Vacancies.Db.Synchronization.EventHandlers.Employments;
using Vacancies.Db.Synchronization.EventHandlers.Geographic;
using Vacancies.Db.Synchronization.EventHandlers.Geographic.Metro;
using Vacancies.Db.Synchronization.EventHandlers.Industries;
using Vacancies.Db.Synchronization.EventHandlers.Languages;
using Vacancies.Db.Synchronization.EventHandlers.Negotiations;
using Vacancies.Db.Synchronization.EventHandlers.Salaries;
using Vacancies.Db.Synchronization.EventHandlers.Schedules;
using Vacancies.Db.Synchronization.EventHandlers.Skills;
using Vacancies.Db.Synchronization.EventHandlers.Specializations;
using Vacancies.Db.Synchronization.EventHandlers.Statuses;
using Vacancies.Db.Synchronization.Events.Driving;
using Vacancies.Db.Synchronization.Events.Employers;
using Vacancies.Db.Synchronization.Events.Employments;
using Vacancies.Db.Synchronization.Events.Geographic;
using Vacancies.Db.Synchronization.Events.Geographic.Metro;
using Vacancies.Db.Synchronization.Events.Industries;
using Vacancies.Db.Synchronization.Events.Languages;
using Vacancies.Db.Synchronization.Events.Negotiations;
using Vacancies.Db.Synchronization.Events.Salaries;
using Vacancies.Db.Synchronization.Events.Schedules;
using Vacancies.Db.Synchronization.Events.Skills;
using Vacancies.Db.Synchronization.Events.Specializations;
using Vacancies.Db.Synchronization.Events.Statuses;
using Vacancies.Export;
using Vacancies.Export.ModelBuilders;

namespace Vacancies.API
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
            services.AddDbContext<VacanciesDbContext>(opt =>
            {
                opt.UseSqlServer(
                    Configuration["ConnectionString"],
                    sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(typeof(VacanciesDbContext)
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

                builder.SubscriptionClientName = Configuration["EventBusSubscriptionClientName"];
                builder.RetryCount = retryCount;

                builder.RegisterEventHandler<DrivingLicenseTypesChangedHandler>();
                builder.RegisterEventHandler<EmployersChangedHandler>();
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
                builder.RegisterEventHandler<VacancyStatusesChangedHandler>();
                builder.RegisterEventHandler<SpecializationsChangedHandler>();
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

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.Authority = Configuration["IdentityUrl"];
                options.Audience = "vacancies";
                options.RequireHttpsMetadata = false;
            });

            services.AddScoped<VacancyService>();

            services.AddJsReport(new ReportingService(Configuration["JsReport"]));

            services.AddTransient<IVacancyExportModelBuilder, VacancyExportModelBuilder>();

            services.AddSingleton<IVacancyExporter, VacancyExporter>(sp => {
                var env = sp.GetService<IHostingEnvironment>();
                var path = Path.Combine(env.ContentRootPath, Configuration["ExportTemplatesPath"]);
                var engine = new RazorLightEngineBuilder()
                    .UseFilesystemProject(path)
                    .UseMemoryCachingProvider()
                    .Build();
                var exportView = Configuration["ExportTemplate"];
                var reporter = sp.GetService<IJsReportMVCService>();
                var modelBuilder = sp.GetService<IVacancyExportModelBuilder>();
                var exporter = new VacancyExporter(reporter, engine, modelBuilder, exportView);

                return exporter;
            });

            services.AddSingleton<VacancyExportTaskStorage>();
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

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(
                    Configuration["SwaggerEndpointUrl"],
                    Configuration["SwaggerEndpointName"]);
            });

            app.UseEventBusRabbitMQ(eventBus =>
            {
                eventBus.Subscribe<DrivingLicenseTypesChanged, DrivingLicenseTypesChangedHandler>();
                eventBus.Subscribe<EmployersChanged, EmployersChangedHandler>();
                eventBus.Subscribe<EmploymentsChanged, EmploymentsChangedHandler>();
                eventBus.Subscribe<LinesChanged, LinesChangedHandler>();
                eventBus.Subscribe<MetroChanged, MetroChangedHandler>();
                eventBus.Subscribe<StationsChanged, StationsChangedHandler>();
                eventBus.Subscribe<AreasChanged, AreasChangedHandler>();
                eventBus.Subscribe<IndustriesChanged, IndustriesChangedHandler>();
                eventBus.Subscribe<LanguageLevelsChanged, LanguageLevelsChangedHandler>();
                eventBus.Subscribe<LanguagesChanged, LanguagesChangedHandler>();
                eventBus.Subscribe<ResponsesChanged, ResponsesChangedHandler>();
                eventBus.Subscribe<CurrenciesChanged, CurrenciesChangedHandler>();
                eventBus.Subscribe<SchedulesChanged, SchedulesChangedHandler>();
                eventBus.Subscribe<SkillsChanged, SkillsChangedHandler>();
                eventBus.Subscribe<VacancyStatusesChanged, VacancyStatusesChangedHandler>();
                eventBus.Subscribe<SpecializationsChanged, SpecializationsChangedHandler>();
            });
        }
    }
}
>>>>>>> jsreport
