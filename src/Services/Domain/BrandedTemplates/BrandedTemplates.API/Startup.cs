using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using BuildingBlocks.Extensions.AutoMapper;
using BrandedTemplates.Db;
using BrandedTemplates.Db.Dto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Swashbuckle.AspNetCore.Swagger;

namespace BrandedTemplates.API
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
            services.AddDbContext<BrandedTemplatesDbContext>(opt =>
            {
                opt.UseSqlServer(
                    Configuration["ConnectionString"],
                    sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(typeof(BrandedTemplatesDbContext)
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

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.Authority = Configuration["IdentityUrl"];
                options.Audience = "brandedtemplates";
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
        }
    }
}
