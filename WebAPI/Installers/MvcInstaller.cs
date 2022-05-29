using Aplication;
using Aplication.Validators;
using FluentValidation.AspNetCore;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAPI.Middelwares;

namespace WebAPI.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAplication();
            services.AddInfrastructure();

            services.AddControllers()
                .AddNewtonsoftJson()
                .AddFluentValidation(option =>
                {
                    option.RegisterValidatorsFromAssemblyContaining<CreateToDoTaskDtoValidator>();
                });

            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            });

            services.AddScoped<ErrorHandlingMiddelware>();
        }
    }
}
