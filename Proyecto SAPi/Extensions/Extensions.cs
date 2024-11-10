using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Model.Data;
using Proyecto_SAPi.Security;
using Service.Services;
using Service.Services.Contract;
using System.Buffers.Text;
using System.Text;

namespace Proyecto_SAPi.Extensions
{
    public static class Extensions
    {
        public static void ConfigureContext(this IServiceCollection services, IConfiguration configuration)
        {
            string? connection = configuration.GetConnectionString("SapDataBase");

            if (connection is null) throw new ArgumentNullException(nameof(connection));

            services.AddSqlServer<SapContext>(connection);
        }

        public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration) 
        {
            services.Configure<JwtOptions>(configuration.GetSection("JwtOptions"));
        }

        public static void ConfigureAuthentication(this IServiceCollection services) 
        {
            services.AddAuthentication("Bearer")
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme);

            services.AddSingleton<IConfigureNamedOptions<JwtBearerOptions>, ConfigureJwtOptions>();
        }

        public static void ConfigureEncryption(this IServiceCollection services, IConfiguration configuration) 
        {
            string key = configuration["Encryption:Key"] ?? "";

            services.AddSingleton<IEncryptionService>(provider => {
                return new EncryptionService(Convert.FromBase64String(key));
            });
        }
    }
}
