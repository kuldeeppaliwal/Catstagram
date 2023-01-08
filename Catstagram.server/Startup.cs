namespace Catstagram.server
{
    using Catstagram.server.Data;
    using Catstagram.server.Infrastructure;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services.AddDatabase(this.Configuration)
                       .AddIdentity()
                       .AddJwtAuthentication(services.GetApplicationSettings(this.Configuration))
                       .AddApplicationServices()
                       .AddControllers();



        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            if (env.IsDevelopment())
            {
                app.UseDatabaseErrorPage();
            }

            app.UseRouting()
               .UseCors(options => options
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod())

               .UseAuthentication()
               .UseAuthorization()

               .UseEndpoints(endpoints =>
               {
                   endpoints.MapControllers();
               })

              .ApplyMigrations();
        }
    }
}
