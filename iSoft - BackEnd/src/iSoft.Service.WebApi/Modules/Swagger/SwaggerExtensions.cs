﻿using Microsoft.OpenApi.Models;
using System.Reflection;

namespace iSoft.Service.WebApi.Modules.Swagger
{
  public static class SwaggerExtensions
  {

    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
      // Register the Swagger generator, defining 1 or more Swagger documents
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
          Version = "v1",
          Title = "iSoft Software ERP",
          Description = "Un simple ejemplo de ASP.NET Core Web API",
          TermsOfService = new Uri("https://pacagroup.com/terms"),
          Contact = new OpenApiContact
          {
            Name = "Jorge Torres",
            Email = "jorge1208.ta@gmail.com",
            Url = new Uri("https://pacagroup.com/contact")
          },
          License = new OpenApiLicense
          {
            Name = "Use under LICX",
            Url = new Uri("https://pacagroup.com/licence")
          }
        });
        // Set the comments path for the Swagger JSON and UI.
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        c.IncludeXmlComments(xmlPath);

        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
          Description = "Authorization by API key.",
          In = ParameterLocation.Header,
          Type = SecuritySchemeType.ApiKey,
          Name = "Authorization"
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement {
          {
            new OpenApiSecurityScheme
            {
              Reference = new OpenApiReference
              {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
              }
            },
            new string[]{ }
          }
          });
      });
      return services;
    }

  }
}