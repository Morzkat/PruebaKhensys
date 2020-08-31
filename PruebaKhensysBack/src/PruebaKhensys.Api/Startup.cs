using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PruebaKhensys.Application.Services;
using PruebaKhensys.Core.Entities.DTOS;
using PruebaKhensys.Core.Interfaces.Persistence;
using PruebaKhensys.Core.Interfaces.Services;
using PruebaKhensys.Infrastructure.AppMapper;
using PruebaKhensys.Infrastructure.Persistence;
using PruebaKhensys.Infrastructure.Persistence.Context;
using PruebaKhensys.Infrastructure.Validators;

namespace PruebaKhensys.Api
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
            services.AddControllers();

            services.AddDbContext<PruebaKhensysContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("PruebaKhensysContext")));

            //
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAppMapper, AppMapper>();

            //Services
            services.AddScoped<IEmployeesService, EmployeesService>();
            services.AddScoped<IRolesService, RolesService>();

            //Validations:
            services.AddSingleton<IValidator<RoleDTO>, RoleValidator>();
            services.AddSingleton<IValidator<EmployeeDTO>, EmployeeValidator>();

            var client = Configuration.GetSection("ClientHost").Value;

            // Cors
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                   builder => builder
                    .WithOrigins(Configuration.GetSection("ClientHost").Value)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                  );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors("CorsPolicy");
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
