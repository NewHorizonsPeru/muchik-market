using Microsoft.EntityFrameworkCore;
using midis.muchik.market.application.interfaces;
using midis.muchik.market.application.mappings;
using midis.muchik.market.application.services;
using midis.muchik.market.crosscutting.interfaces;
using midis.muchik.market.crosscutting.jwt;
using midis.muchik.market.domain.interfaces;
using midis.muchik.market.infrastructure.context;
using midis.muchik.market.infrastructure.repositories;

namespace midis.muchik.market.api.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddMappgins(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(EntityToDtoProfile));
            return services;
        }

        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CommonContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("MuchikMsSql"));
            });

            services.AddDbContext<SecurityContext>(opt =>
            {
                opt.UseMySQL(configuration.GetConnectionString("MuchikMySql")!);
            });

            services.AddDbContext<OmnichannelContext>(opt =>
            {
                opt.UseNpgsql(configuration.GetConnectionString("MuchikPgSql")!);
            });

            return services;
        }

        public static IServiceCollection AddDependencyContainer(this IServiceCollection services)
        {
            //Cross-Cutting
            services.AddTransient<IJwtManger, JwtManager>();

            // Services
            services.AddTransient<ICommonService, CommonService>();
            services.AddTransient<ISecurityService, SecurityService>();

            //Repositories
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddTransient<IUserRepository, UserRepository>();

            //Contexts
            services.AddTransient<SecurityContext>();
            services.AddTransient<CommonContext>();
            services.AddTransient<OmnichannelContext>();

            return services;
        }
    }
}
