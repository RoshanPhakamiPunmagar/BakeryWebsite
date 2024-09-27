using BakeryWebsite.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BakeryWebsite.Services;
using System;


namespace BakeryWebsite
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Register DbContext
            services.AddDbContext<StoreDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("StoreDbConnection")));

            // Register Repository
            services.AddScoped<IStoreRepository, EFStoreRepository>();

            // Register Session Services
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(70); // Set session timeout to 70 minutes
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            // Register HttpContextAccessor (only need this once)
            services.AddHttpContextAccessor();

            // Register the ShoppingCartService for dependency injection
            services.AddScoped<IShoppingCartService, ShoppingCartService>();

            // Register MVC Services
            services.AddControllersWithViews();

            // Optional: If you need Authorization services
            services.AddAuthorization();
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
            app.UseSession();  // Enable session
            app.UseAuthorization();   // Ensure this is after UseRouting and before UseEndpoints

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            // If you want a specific route for Cart
            endpoints.MapControllerRoute(
                name: "cart",
                pattern: "Cart",
                defaults: new { controller = "ShoppingCart", action = "Cart" });
        });

          


            // Seed Data
            SeedData.EnsurePopulated(app);
        }
    }
}
