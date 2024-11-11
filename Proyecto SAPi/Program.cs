using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Proyecto_SAPi.Extensions;
using Service.Services;
using Service.Services.Contract;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.ConfigureLogger();

var logger = NLog.LogManager.GetCurrentClassLogger();

logger.Info("Start Building");

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

logger.Info("Ready Swagger");

// Implement configuration
builder.Services.ConfigureContext(builder.Configuration);
builder.Services.ConfigureJwt(builder.Configuration);
builder.Services.ConfigureEncryption(builder.Configuration);

logger.Info("Ready Config");

// Layer Service
builder.Services.AddScoped<ILoggerService, LoggerService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<IRecordService, RecordService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUnitService, UnitService>();
builder.Services.AddScoped<IUserService, UserService>();

logger.Info("Ready Services");

//Jwt
builder.Services.ConfigureAuthentication();
builder.Services.ConfigureAuthorization();

logger.Info("Ready Authentication");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsProduction())
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseLogger();

app.MapControllers();

app.MapGet("/hello", () => Results.Ok("hi")).RequireAuthorization();

app.Run();

logger.Info("Runing");
