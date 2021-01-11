using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Restaurants.Users.Api.Authentication;
using Restaurants.Users.Api.Models.EntityModels;
using System;
using System.Text;

namespace Restaurants.Users.Api.Extensions
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Defines Cross-Origin Resource Sharing (CORS) policies:
        /// "OpenCORS" – Completely unrestricted CORS (suitable for development environments).
        /// TODO: Define policies for staging and production.
        /// </summary>
        /// <param name="services">The services available in the application.</param>
        /// <returns>Return the calling IServiceCollection instance with CORS configurations added.</returns>
        public static IServiceCollection ConfigureCors(this IServiceCollection services)
        {
            return services.AddCors(options =>
            {
                options.AddPolicy("OpenCORS",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        /// <summary>
        /// Defines the DbContextOptions for a PostgreSQL database context.
        /// </summary>
        /// <param name="services">The services available in the application.</param>
        /// <param name="config">The configuration settings available in the application.</param>
        /// <returns>Returns the calling IServiceCollection instance with PostgreSQL database context configurations added.</returns>
        public static IServiceCollection ConfigureNpgsql(this IServiceCollection services, IConfiguration config)
        {
            return services
                .AddDbContext<AppDbContext>(
                    options => options.UseNpgsql(config.GetConnectionString("DefaultConnection"))
                );
        }

        /// <summary>
        /// Configures JwtOptions from values specified in appsettings.
        /// </summary>
        /// <param name="services">The services available in the application.</param>
        /// <param name="config">The configuration settings available in the application.</param>
        /// <returns>Returns the calling IServiceCollection instance with JWT configurations added.</returns>
        public static IServiceCollection ConfigureJwtOptions(this IServiceCollection services, IConfiguration config)
        {
            var jwtAppSettingOptions = config.GetSection(nameof(JwtOptions));
            var signingKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtAppSettingOptions[nameof(JwtOptions.SecretKey)])
            );

            return services.Configure<JwtOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtOptions.Audience)];
                options.SecretKey = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            });
        }

        /// <summary>
        /// Configures JWT Authentication middleware.
        /// </summary>
        /// <param name="services">The services available in the application.</param>
        /// <param name="config">The configuration settings available in the application.</param>
        /// <returns>Returns the calling IServiceCollection instance with Authentication middleware configured.</returns>
        public static IServiceCollection ConfigureAuthentication(this IServiceCollection services, IConfiguration config)
        {
            var jwtAppSettingOptions = config.GetSection(nameof(JwtOptions));
            var signingKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtAppSettingOptions[nameof(JwtOptions.SecretKey)])
            );

            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = false;
                    options.ClaimsIssuer = jwtAppSettingOptions[nameof(JwtOptions.Issuer)];
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = jwtAppSettingOptions[nameof(JwtOptions.Issuer)],
                        ValidateAudience = true,
                        ValidAudience = jwtAppSettingOptions[nameof(JwtOptions.Audience)],
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = signingKey,
                        RequireExpirationTime = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.FromMinutes(5)
                    };
                });

            return services;
        }

        /// <summary>
        /// Configures the ASP.NET Identity system for user login and password management.
        /// </summary>
        /// <param name="services">The services available in the application.</param>
        /// <returns>Returns the calling IServiceCollection instance with the Identity system configured and added.</returns>
        public static IServiceCollection ConfigureIdentity(this IServiceCollection services)
        {
            services
                .AddIdentityCore<AppUserModel>(options =>
                {
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequiredLength = 8;

                    options.SignIn.RequireConfirmedEmail = false;
                    options.SignIn.RequireConfirmedPhoneNumber = false;

                    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                    options.User.RequireUniqueEmail = false;
                })
                .AddRoles<IdentityRole>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<AppDbContext>();

            return services;
        }
    }
}
