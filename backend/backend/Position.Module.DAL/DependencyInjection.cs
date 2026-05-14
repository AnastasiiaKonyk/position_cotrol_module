using Microsoft.EntityFrameworkCore;
using backend.Position.Module.DAL.Interface;
using backend.Position.Module.DAL.Repositories;

namespace backend.Position.Module.DAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TypePosadDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}