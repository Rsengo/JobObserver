﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BuildingBlocks.Extensions.AutoMapper;
using BuildingBlocks.Extensions.EventBus.RabbitMQ;
using Employers.Db;
using Employers.Synchronization.EventHandlers;
using Employers.Synchronization.EventHandlers.EducationalInstitutions;
using Employers.Synchronization.EventHandlers.Geographic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace Employers.API
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
            services.AddDbContext<EmployersDbContext>(opt =>
            {
                opt.UseSqlServer(
                    Configuration["ConnectionString"],
                    sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(typeof(EmployersDbContext)
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
                builder.RootAssembly = GetType().Assembly;
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

                builder.RegisterEventHandler<EmployersChangedHandler>();
                builder.RegisterEventHandler<EmployerTypesChangedHandler>();
                builder.RegisterEventHandler<AreasChangedHandler>();
                builder.RegisterEventHandler<EducationalInstitutionsChangedHandler>();
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
