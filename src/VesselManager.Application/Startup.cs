using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using VesselManager.Domain.Interfaces;
using VesselManager.Domain.Interfaces.Services;
using VesselManager.Infra.Context;
using VesselManager.Infra.Repository;
using VesselManager.Service.Services;

namespace VesselManager.Application
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
            services.AddDbContext<BdContext>(
                options => options.UseSqlServer("Data Source=.\\SQLEXPRESS2017;Initial Catalog=vesselDb;Integrated Security=True;")
            );
            services.AddScoped<IVesselService, VesselService>();
            services.AddScoped<IEquipamentService, EquipamentService>();
            services.AddScoped<IEquipamentRepository, EquipamentRepository>();
            services.AddScoped<IVesselRepository, VesselRepository>();
            services.AddControllers();

            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Vessel Manager by Douglas dos Santos");
                c.RoutePrefix = string.Empty;
            });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
