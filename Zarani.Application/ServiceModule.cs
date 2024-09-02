using DogusOto.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using Zarani.Application.Mapper;
using Zarani.Common.IOC;
using Zarani.Common.Settings;


namespace Zarani.Application
{
    public static class ServiceModule
    {
        public static void Configure(IServiceCollection services, ConfigurationManager configuration)
        {
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            services.UseIocLoader();

            InfrastructureModule.Configure(services, configuration);

            services.AddAutoMapper(typeof(MapProfile));

            services.Configure<TokenOptionsSetting>(configuration.GetRequiredSection(nameof(TokenOptionsSetting)));
            services.AddSingleton<ITokenOptionsSetting>(provider => provider.GetRequiredService<IOptions<TokenOptionsSetting>>().Value);
            serviceProvider = services.BuildServiceProvider();
            ITokenOptionsSetting tokenOptionsSetting = serviceProvider.GetRequiredService<ITokenOptionsSetting>();


            //jwt token
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, configureOptions =>
                      {
                          configureOptions.TokenValidationParameters = new TokenValidationParameters()
                          {
                              ValidIssuer = tokenOptionsSetting.Issuer,
                              ValidAudience = tokenOptionsSetting.Audiences[0],
                              IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptionsSetting.SecurityKey)),
                              ValidateIssuer = true,
                              ValidateAudience = true,
                              ValidateIssuerSigningKey = true,
                              ValidateLifetime = true,
                              ClockSkew = TimeSpan.FromMinutes(1)
                          };
                      });
        }
    }
}
