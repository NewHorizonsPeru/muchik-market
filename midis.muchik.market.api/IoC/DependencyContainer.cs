using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using midis.muchik.market.application.interfaces;
using midis.muchik.market.application.mappings;
using midis.muchik.market.application.services;
using midis.muchik.market.crosscutting.interfaces;
using midis.muchik.market.crosscutting.jwt;
using midis.muchik.market.domain.interfaces;
using midis.muchik.market.infrastructure.context;
using midis.muchik.market.infrastructure.repositories;
using System.Text;

namespace midis.muchik.market.api.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddMappgins(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(EntityToDtoProfile), typeof(DtoToEntityProfile));
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
            services.AddTransient<IOmnichannelService, OmnichannelService>();

            //Repositories
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();

            //Contexts
            services.AddTransient<SecurityContext>();
            services.AddTransient<CommonContext>();
            services.AddTransient<OmnichannelContext>();

            return services;
        }

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.
                AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration.GetValue<string>("JwtConfig:Issuer"),
                        ValidAudience = configuration.GetValue<string>("JwtConfig:Audience"),
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("JwtConfig:SecretKet")!))
                    };
                });

            return services;
        }
    }
}
