using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Polly.Application.Repositories;
using Polly.Application.Services.SecurityServices;
using Polly.Infrastructure.Repositories;
using Polly.Infrastructure.Services.SecurityServices;

namespace Polly.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static void MyRepository(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ISessionService, SessionService>();
            services.AddTransient<ISecurityRepository, SecurityRepository>();
        }
    }
}
