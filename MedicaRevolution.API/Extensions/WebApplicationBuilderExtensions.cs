﻿using MedicaRevolution.API.Middlewares;
using Microsoft.OpenApi.Models;
using Serilog;

namespace MedicaRevolution.API.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void AddPresentation(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication();
        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "bearerAuth"} }, []
        }
    });
        });
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddScoped<ErrorHandlingMiddle>();
        builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration)
);
    }
}
