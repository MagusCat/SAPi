using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Proyecto_SAPi.Security
{
    public class ConfigureJwtOptions : IConfigureNamedOptions<JwtBearerOptions>
    {
        private readonly JwtOptions _options;

        public ConfigureJwtOptions(IOptions<JwtOptions> options) 
        {
            _options = options.Value;
        }

        public void Configure(string? name, JwtBearerOptions opt)
        {
            Console.WriteLine(name);


            if (name != JwtBearerDefaults.AuthenticationScheme) return;

            Console.WriteLine("Configured");

            opt.RequireHttpsMetadata = false;
            opt.SaveToken = true;
            opt.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = false,
                ValidateAudience = false,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(_options.GetKey()),
            };
        }

        public void Configure(JwtBearerOptions options)
        {
            Configure(string.Empty, options);
        }
    }
}
