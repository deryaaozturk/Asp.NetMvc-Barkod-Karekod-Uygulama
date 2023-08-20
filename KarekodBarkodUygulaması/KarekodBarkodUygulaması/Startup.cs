using KarekodBarkodUygulaması.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using KarekodBarkodUygulaması.Pages.Service;

namespace KarekodBarkodUygulaması
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
            services.AddControllersWithViews();

            //Appsettings.json içerisinde belirttiğimiz mssql bağlantı cümlesini burada UseSqlserver fonksiyonu içerisinde kullanıyoruz
            //Database oluşturma işlemleri
            services.AddDbContext<DatabaseContext>(opts => {
                //UseSqlServer fonksiyonunu kullanmak için nuget paketleri arasında EFCore.SqlServer paketi yüklendi.
                opts.UseSqlServer(
                    Configuration["ConnectionStrings:ProductConnection"]);
            });
            services.AddScoped<IProductsRepository, EFProductsRepository>();
            services.AddRazorPages();
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddScoped<IOrderRepository, EFOrderRepository>();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddServerSideBlazor();
            //admin için ayrı bir veritabanı kullanılacağız bunun için ikinci bir bağlantı adresi belirtiyoruz
            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(
                    Configuration["ConnectionStrings:IdentityConnection"]));
            services.AddIdentity<UserModel, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>();

            services.AddScoped<IFileUpload, FileUpload>();

            
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

            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/admin/{*catchall}", "/Admin/Index");
            });

            //SeedData ile oluşturduğumuz denemelik ürünlerin kaydını oluşturmak için belirtiyoruz
            SeedData.EnsurePopulated(app);
            IdentitySeedData.EnsurePopulated(app);
        }
    }
}
