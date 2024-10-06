using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Portfolio.Services;
namespace Portfolio
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        
            services.AddControllers();

        
            services.AddScoped<IUserService, UserService>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts(); 
            }

            app.UseHttpsRedirection(); 
            app.UseStaticFiles();

            app.UseRouting(); 

            app.UseAuthentication(); 
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
