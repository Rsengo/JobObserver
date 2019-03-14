using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BuildingBlocks.Extensions.AutoMapper;
using BuildingBlocks.Extensions.EventBus.RabbitMQ;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Resumes.Db;
using Resumes.Synchronization.EventHandlers.Applicants;
using Resumes.Synchronization.EventHandlers.Driving;
using Resumes.Synchronization.EventHandlers.Educations;
using Resumes.Synchronization.EventHandlers.Employments;
using Resumes.Synchronization.EventHandlers.Geographic;
using Resumes.Synchronization.EventHandlers.Geographic.Metro;
using Resumes.Synchronization.EventHandlers.Industries;
using Resumes.Synchronization.EventHandlers.Languages;
using Resumes.Synchronization.EventHandlers.Negotiations;
using Resumes.Synchronization.EventHandlers.Salaries;
using Resumes.Synchronization.EventHandlers.Schedules;
using Resumes.Synchronization.EventHandlers.Skills;
using Resumes.Synchronization.EventHandlers.Specializations;
using Resumes.Synchronization.EventHandlers.Statuses;
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

            services.AddAutoMapper(builder => { builder.RootAssembly = GetType().Assembly; });

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

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(
                    Configuration["SwaggerEndpointUrl"],
                    Configuration["SwaggerEndpointName"]);
            });
        }
    }
}
