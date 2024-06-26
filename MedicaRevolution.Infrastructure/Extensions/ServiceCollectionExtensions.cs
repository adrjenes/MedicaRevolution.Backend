using MedicaRevolution.Domain.Entities;
using MedicaRevolution.Domain.Interfaces;
using MedicaRevolution.Domain.Repositories;
using MedicaRevolution.Infrastructure.Configuration;
using MedicaRevolution.Infrastructure.Persistence;
using MedicaRevolution.Infrastructure.Repositories;
using MedicaRevolution.Infrastructure.Seeders;
using MedicaRevolution.Infrastructure.Storage;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MedicaRevolution.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MedicaRevolutionDb");
        services.AddDbContext<MedicaRevolutionDbContext>(options =>
            options.UseSqlServer(connectionString)
                .EnableSensitiveDataLogging());
        services.AddScoped<IPatientRepository, PatientRepository>();
        services.AddScoped<IDoctorRepository, DoctorRepository>();
        // IDENTITY
        services.AddIdentity<User, IdentityRole>(options =>
        {
            options.Password.RequiredLength = 6;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
        })
        .AddEntityFrameworkStores<MedicaRevolutionDbContext>()
        .AddDefaultTokenProviders();

        // AUTHENTICATION
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        // BEARER
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["JWT:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]))
            };
        });

        // AUTHORIZATION
        services.AddAuthorization(options =>
        {
            options.AddPolicy("DoctorPolicy", policy => policy.RequireRole("Doctor"));
            options.AddPolicy("PatientPolicy", policy => policy.RequireRole("Patient"));
        });
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
        });
        services.AddScoped<IMedicaRevolutionSeeder, MedicaRevolutionSeeder>();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddTransient<TokenService>();
        services.Configure<BlobStorageSettings>(configuration.GetSection("BlobStorage"));
        services.AddScoped<IBlobStorageService, BlobStorageService>();
    }
}