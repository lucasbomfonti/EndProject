using System;
using EndProject.Infra.Persistence;
using EndProject.Infra.Persistence.Repositores;
using EndProject.Service.Interfaces;
using EndProject.Service.Repositories;
using EndProject.Service.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using XGame.Api.Security;

namespace EndProject.API
{
    public class Startup
    {
        public Startup(IHostingEnvironment environment)
        {
            var builder = new ConfigurationBuilder().SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IServicePlayer, ServicePlayer>();
            services.AddTransient<IRepositoryPlayer, RepositoryPlayer>();
            services.AddMvc();

            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info { Title = "APIUsuarios", Version = "v1" }); });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();

            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "APIUsuarios V1"); });

        }
    }
    
}
