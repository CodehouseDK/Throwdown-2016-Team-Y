using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc.Filters;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TeamY.Infrastructure;
using TeamY.Services;

namespace TeamY
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = @"Data Source=DK-SQL2014;Initial Catalog=Hackathon.TeamY;User ID=teamy;Password=teamgalaxy;";
            services.AddAuthorization();
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
            services.AddSingleton<INameService, NameService>();
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<TeamyDbContext>(options => options.UseSqlServer(connection));
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            app.UseCookieAuthentication(options =>
            {
                options.AuthenticationScheme = "Cookie";
                options.LoginPath = new PathString("/Account/Login/");
                options.AccessDeniedPath = new PathString("/Account/Forbidden/");
                options.AutomaticAuthenticate = true;
                options.AutomaticChallenge = true;
            });

            app.UseIISPlatformHandler();

            app.UseDeveloperExceptionPage();

            app.UseMvcWithDefaultRoute();

            app.UseStaticFiles();
        }
    }
}