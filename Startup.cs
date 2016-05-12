using Microsoft.AspNet.Builder;
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
            services.AddMvc();
            services.AddSingleton<INameService, NameService>();
            services.AddEntityFramework()
               .AddSqlServer()
               .AddDbContext<TeamyDbContext>(options => options.UseSqlServer(connection));
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            
            app.UseIISPlatformHandler();
            
            app.UseDeveloperExceptionPage();

            app.UseMvcWithDefaultRoute();
            
            app.UseStaticFiles();
            
        }
    }
}