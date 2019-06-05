using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using BuildingBlocks.Extensions.AutoMapper;
using BuildingBlocks.Extensions.EventBus.RabbitMQ;
using Login.Db;
using Login.Db.Synchronization.EventHandlers.Contacts;
using Login.Db.Synchronization.EventHandlers.Genders;
using Login.Db.Synchronization.EventHandlers.Geographic;
using Login.Db.Synchronization.Events.Contacts;
using Login.Db.Synchronization.Events.Genders;
using Login.Db.Synchronization.Events.Geographic;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;
using IdentityServer4.AspNetIdentity;
using IdentityServer4.Services;
using Login.API.Services;
using Login.Db.Models;
using Login.Db.Dto;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using Login.API.HttpFilters;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Login.API.Data;
using Login.API.Certificates;

namespace Login.API
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
            services.AddDbContext<LoginDbContext>(opt =>
            {
                opt.UseSqlServer(
                    Configuration["ConnectionString"],
                    sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(typeof(LoginDbContext)
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

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<LoginDbContext>()
                .AddDefaultTokenProviders();

            services.AddIdentityServer(x =>
            {
                x.IssuerUri = "null";
                x.Authentication.CookieLifetime = TimeSpan.FromHours(2);
                x.Cors.CorsPolicyName = Configuration["CorsPolicy"];
            })
                //.AddSigningCredential(Certificate.Get())
                .AddDeveloperSigningCredential(persistKey: true)
                .AddAspNetIdentity<User>()
                .AddConfigurationStore(opt =>
                {
                    opt.ConfigureDbContext = builder => builder.UseSqlServer(
                        Configuration["ConnectionString"],
                        sqlOptions =>
                        {
                            sqlOptions.MigrationsAssembly(typeof(LoginDbContext)
                                .GetTypeInfo()
                                .Assembly
                                .GetName()
                                .Name);
                            sqlOptions.EnableRetryOnFailure(
                                15,
                                TimeSpan.FromSeconds(30),
                                null);
                        });
                })
                .AddOperationalStore(opt =>
                {
                    opt.ConfigureDbContext = builder => builder.UseSqlServer(
                        Configuration["ConnectionString"],
                        sqlOptions =>
                        {
                            sqlOptions.MigrationsAssembly(typeof(LoginDbContext)
                                .GetTypeInfo()
                                .Assembly
                                .GetName()
                                .Name);
                            sqlOptions.EnableRetryOnFailure(
                                15,
                                TimeSpan.FromSeconds(30),
                                null);
                        });
                })
                .AddProfileService<ProfileService>();

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

                builder.RegisterEventHandler<SiteTypesChangedHandler>();
                builder.RegisterEventHandler<GendersChangedHandler>();
                builder.RegisterEventHandler<AreasChangedHandler>();
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

            services.AddScoped<IRegistrationService, RegistrationService>();

            //services.AddSingleton<ICryptoService>(sp =>
            //{
            //    var hash = new MD5CryptoServiceProvider();
            //    var symmetricAlgorithm = new TripleDESCryptoServiceProvider();
            //    var key = Configuration["SymmetricKey"];
            //    var cryptoService = new CryptoService(symmetricAlgorithm, hash, key);

            //    return cryptoService;
            //});

            services.AddTransient<ICryptoService, Base64CryptoService>();

            services.Configure<RedirectSettings>(Configuration);
            services.AddOptions();

            services.AddTransient<LoginDbContextSeed>();

            services.AddMvc(opt =>
            {
                opt.Filters.Add<HttpGlobalExceptionFilter>();
                //opt.Filters.Add<ValidateModelStateFilter>();
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
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
                //app.UseHsts();
            }

            app.UseCors(Configuration["CorsPolicy"]);


            //Make work identity server redirections in Edge and lastest versions of browers. WARN: Not valid in a production environment.
           //app.Use(async (context, next) =>
           //{
           //    context.Response.Headers.Add("Content-Security-Policy", "script-src 'unsafe-inline'");
           //    await next();
           //});

            app.UseForwardedHeaders();

            app.UseIdentityServer();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(
                    Configuration["SwaggerEndpointUrl"],
                    Configuration["SwaggerEndpointName"]);
            });

            app.UseEventBusRabbitMQ(eventBus =>
            {
                eventBus.Subscribe<SiteTypesChanged, SiteTypesChangedHandler>();
                eventBus.Subscribe<GendersChanged, GendersChangedHandler>();
                eventBus.Subscribe<AreasChanged, AreasChangedHandler>();
            });
        }
    }
}
