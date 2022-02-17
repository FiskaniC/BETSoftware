using System.Reflection;
using AutoMapper;
using BETShop.Application.Common.Interfaces.Configuration;
using BETShop.Application.Common.Interfaces.Repositories;
using BETShop.Application.Common.Interfaces.Services;
using BETShop.Infrastructure.Configuration;
using BETShop.Infrastructure.Data;
using BETShop.Infrastructure.Repositories;
using BETShop.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BETShop.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BETShopContext>(o => o.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<ISessionService, SessionService>();
            services.AddTransient<ICartService, CartService>();
            services.AddTransient<IEmailService, EmailService>();

            services.Configure<MongoDatabaseConfiguration>(
                configuration.GetSection(nameof(MongoDatabaseConfiguration)));

            services.AddSingleton<IDatabaseConfiguration>(sp =>
                sp.GetRequiredService<IOptions<MongoDatabaseConfiguration>>().Value);

            var emailSenderConfiguration = new EmailServiceConfiguration();
            configuration.GetSection(nameof(EmailServiceConfiguration)).Bind(emailSenderConfiguration);
            services.AddSingleton(emailSenderConfiguration);

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
