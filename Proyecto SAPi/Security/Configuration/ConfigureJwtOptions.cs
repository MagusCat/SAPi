using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Service.Services.Contract;
using System.Security.Claims;

namespace Proyecto_SAPi.Security.Configuration
{
    public class ConfigureJwtOptions : IConfigureNamedOptions<JwtBearerOptions>
    {
        private readonly JwtOptions _options;

        public ConfigureJwtOptions(IOptions<JwtOptions> options)
        {
            _options = options.Value;
        }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
        public void Configure(string? name, JwtBearerOptions opt)
        {
            if (name != JwtBearerDefaults.AuthenticationScheme) return;

            opt.RequireHttpsMetadata = false;
            opt.SaveToken = true;
            opt.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(_options.GetKey()),
            };
            opt.Events = new JwtBearerEvents()
            {
                OnTokenValidated = async (context) =>
                {
                    var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                    var user = context.Principal.Claims.FirstOrDefault(e => e.Type == ClaimTypes.NameIdentifier);
                    var service = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
                    var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<JwtBearerEvents>>();

                    if (token == null || user == null)
                    {
                        context.Fail("No valid request.");
                    }

#pragma warning disable CS8604 // Possible null reference argument.
                    var valido = await service.Authorize(int.Parse(user.Value), token);
#pragma warning restore CS8604 // Possible null reference argument.

                    if (!valido)
                    {
                        var actions = context.HttpContext.RequestServices.GetRequiredService<ILoggerService>();
                        var ip = context.HttpContext.Connection.RemoteIpAddress;
                        var id = int.Parse(user.Value);

                        logger.LogWarning($"Try Expired Token Try used by {user}: {ip}");
                        await actions.Log(id, $"Failure Authentication Token : {ip}", LogLevel.Warning);

                        context.Fail("Invalid token.");
                    }
                },
                OnAuthenticationFailed = (context) =>
                {
                    var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<JwtBearerEvents>>();

                    logger.LogWarning($"Try failure Authentication: {context.Exception.Message}");

                    return Task.CompletedTask;
                }
            };


        }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        public void Configure(JwtBearerOptions options)
        {
            Configure(string.Empty, options);
        }
    }
}
