using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using UrlShortener.Data;
using UrlShortener.Data.Contracts;
using UrlShortener.Services;

namespace UrlShortener
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            
            services.Configure<ShortenedUrlsDatabaseSettings>(
                Configuration.GetSection(nameof(ShortenedUrlsDatabaseSettings)));

            services.AddSingleton<IShortenedUrlsDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<ShortenedUrlsDatabaseSettings>>().Value);

            services.AddScoped<IShortenedUrlsRepository, ShortenedUrlsRepository>();

            services.AddScoped<IShortenedUrlService, ShortenedUrlService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}