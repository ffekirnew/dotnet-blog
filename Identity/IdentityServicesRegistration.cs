using BlogApp.Identity.Models;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using BlogApp.Identity.Services;
using BlogApp.Application.Contracts.Identity.ConfigurationModels;
using BlogApp.Application.Contracts.Identity.Services;
using BlogApp.Identity.Services.DateTimeService;

namespace BlogApp.Identity;

public static class IdentityServicesRegistration
{
  public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services, IConfiguration configuration)
  {
    #region Identity Services
    services.AddTransient<IAuthService, AuthService>();
    services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
    #endregion

    #region Identity Services
    var mongoDbSettings = configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>();
    services
      .AddIdentity<ApplicationUser, ApplicationRole>()
      .AddMongoDbStores<ApplicationUser, ApplicationRole, Guid>
      (
          mongoDbSettings?.ConnectionString, mongoDbSettings?.Name
      );
    #endregion

    #region Authentication and Authorization Services
    services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
    services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(options =>
      {
        var jwtSettings = configuration.GetSection(JwtSettings.SectionName).Get<JwtSettings>()!;

        options.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuer = true,
          ValidateAudience = true,
          ValidateLifetime = true,
          ValidateIssuerSigningKey = true,
          ValidIssuer = jwtSettings.Issuer,
          ValidAudience = jwtSettings.Audience,
          IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key))
        };
      });
    services.AddAuthorization();
    #endregion

    #region Seed Application User and Roles data
    #endregion

    return services;
  }
}
