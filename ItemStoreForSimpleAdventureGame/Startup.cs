using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ItemStoreForSimpleAdventureGame.Models;
using Microsoft.Extensions.Options;
using ItemStoreForSimpleAdventureGame.Services;
using Newtonsoft.Json;

namespace ItemStoreForSimpleAdventureGame
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
            services.Configure<ItemStoreDatabaseSettings>(
        Configuration.GetSection(nameof(ItemStoreDatabaseSettings)));

            services.AddSingleton<IItemStoreDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<ItemStoreDatabaseSettings>>().Value);

            services.AddSingleton<ItemStoreService>();

            services.Configure<BackpackDatabaseSettings>(
        Configuration.GetSection(nameof(BackpackDatabaseSettings)));

            services.AddSingleton<IBackpackDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<BackpackDatabaseSettings>>().Value);

            services.AddSingleton<BackpackService>();

            services.AddControllers();

            services.AddHttpsRedirection(options =>
            {
                options.HttpsPort = 5000;
            }); 

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
