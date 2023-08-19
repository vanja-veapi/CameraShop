using Bugsnag.AspNet.Core;
using CameraShop.API.Core;
using CameraShop.API.DTO;
using CameraShop.API.JWT;
using CameraShop.Application.Core;
using CameraShop.Application.Core.Logging;
using CameraShop.Application.UseCases.UseCaseHandlers;
using CameraShop.EfDataAccess;
using CameraShop.Implementation.Core;
using CameraShop.Implementation.Core.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CameraShop.API
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
            var appSettings = new AppSettings();
            Configuration.Bind(appSettings);

            services.AddHttpContextAccessor();

            services.AddTransient<ITokenStorage, InMemoryTokenStorage>();
            services.AddTransient(x => appSettings);
            services.AddTransient<JwtManager>();
            services.AddTransient<IUseCaseHandler, UseCaseHandler>();
            services.AddTransient<IExceptionLogger, TxtExceptionLogger>();
            services.AddTransient<IUseCaseLogger, EFUseCaseLogging>();

            services.AddTransient<IPictureMenager, PictureMenager>();
            services.AddTransient<IStringEncryptor, MD5Encryptor>();
            services.AddTransient<IEmailSender, SMTPEmailSender>();
           
            services.AddTransient(x =>
            {
                DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
                builder.UseSqlServer(appSettings.DBConnectionString);
                return new CameraShopDbContext(builder.Options);
            });

            services.AddControllers();

            ServicesExtensionMethods.AddAppActor(services);
            ServicesExtensionMethods.AddJwt(services, appSettings);
            ServicesExtensionMethods.AddSwagger(services);
            ServicesExtensionMethods.AddQueryUseCases(services);
            ServicesExtensionMethods.AddCommandUseCases(services);
            ServicesExtensionMethods.AddValidators(services);

            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CameraShop.API v1"));


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware<GlobalExceptionHandler>();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
