using System;
using System.Reflection;
using BuildingBlocks.Extensions.AutoMapper;
using BuildingBlocks.Extensions.EventBus.RabbitMQ;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Vacancies.Db;
using Vacancies.Synchronization.EventHandlers.Driving;
using Vacancies.Synchronization.EventHandlers.Employers;
using Vacancies.Synchronization.EventHandlers.Employments;
using Vacancies.Synchronization.EventHandlers.Geographic;
using Vacancies.Synchronization.EventHandlers.Geographic.Metro;
using Vacancies.Synchronization.EventHandlers.Industries;
using Vacancies.Synchronization.EventHandlers.Languages;
using Vacancies.Synchronization.EventHandlers.Negotiations;
using Vacancies.Synchronization.EventHandlers.Salaries;
using Vacancies.Synchronization.EventHandlers.Schedules;
using Vacancies.Synchronization.EventHandlers.Skills;
using Vacancies.Synchronization.EventHandlers.Statuses;
using Vacancies.Synchronization.Events.Driving;
using Vacancies.Synchronization.Events.Employers;
using Vacancies.Synchronization.Events.Employments;
using Vacancies.Synchronization.Events.Geographic;
using Vacancies.Synchronization.Events.Geographic.Metro;
using Vacancies.Synchronization.Events.Industries;
using Vacancies.Synchronization.Events.Languages;
using Vacancies.Synchronization.Events.Negotiations;
using Vacancies.Synchronization.Events.Salaries;
using Vacancies.Synchronization.Events.Schedules;
using Vacancies.Synchronization.Events.Skills;
using Vacancies.Synchronization.Events.Statuses;

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
            });
        }
    }
}
