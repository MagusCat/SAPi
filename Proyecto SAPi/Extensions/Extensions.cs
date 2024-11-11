using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;
using Model.Data;
using NLog;
using NLog.Extensions.Logging;
using NLog.Web;
using Proyecto_SAPi.Security;
using Proyecto_SAPi.Security.Configuration;
using Service.Services;
using Service.Services.Contract;
using System.Security.Claims;

namespace Proyecto_SAPi.Extensions
{
    public static class Extensions
    {
        public static void ConfigureContext(this IServiceCollection services, IConfiguration configuration)
        {
            string? connection = configuration.GetConnectionString("SapDataBase");

            if (connection is null) throw new ArgumentNullException(nameof(connection));

            services.AddDbContext<SapContext>(opt =>
            {
                opt.UseSqlServer(connection);
                opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                opt.ConfigureWarnings(warnings => warnings
                    .Ignore(CoreEventId.ContextInitialized));
            });
        }

        public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtOptions>(configuration.GetSection("JwtOptions"));
        }

        public static void ConfigureAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer();

            services.ConfigureOptions<ConfigureJwtOptions>();
        }

        public static void ConfigureEncryption(this IServiceCollection services, IConfiguration configuration)
        {
            string key = configuration["Encryption:Key"] ?? "";

            services.AddSingleton<IEncryptionService>(provider =>
            {
                return new EncryptionService(Convert.FromBase64String(key));
            });
        }

        public static void ConfigureLogger(this IServiceCollection services)
        {
            var logger = LogManager.Setup()
                    .LoadConfigurationFromAppSettings()
                    .GetCurrentClassLogger();

            services.AddLogging(log =>
            {
                log.ClearProviders();
                log.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
            });

            services.AddSingleton<ILoggerProvider, NLogLoggerProvider>();
        }

        public static void ConfigureAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("AllowRoot", policy => policy.RequireRole("Root"));
                opt.AddPolicy("AllowAdmin", policy => policy.RequireRole("Admin"));
                opt.AddPolicy("AllowUser", policy => policy.RequireRole("User"));

                opt.AddPolicy("AllowAll", policy => policy.RequireClaim(ClaimTypes.Role));
                opt.AddPolicy("AllowRootOrAdmin", policy => policy.RequireClaim(ClaimTypes.Role, ["Root", "Admin"]));
            });
        }

        public static void UseLogger(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<LoggerActions>();
        }
    }
}
