using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using AutoMapper;


namespace backend.Position.Module.BLL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services, IMapperConfigurationExpression mapConfigExpression, IConfiguration configuration)
        {

            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<Services.Interfaces.ITypePosadService, Services.TypePosadService>();
            return services;
        }

    }
}
