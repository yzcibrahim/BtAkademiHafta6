using _08_DosyaRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KisiTakipMvc
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
            services.AddDbContext<BtaKisiDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("MssqlConnection")));

            services.AddControllersWithViews();

            //  services.AddSingleton<IKisiRepository, JsonRepository>();//uygulama çalıştığı sürece tek bir instanceı kullan
            services.AddScoped<IKisiRepository, EfRepository>();//uygulama çalıştığı sürece tek bir instanceı kullan
            services.AddTransient<Test, Test>();//ihtiyaç duydukça yeni bir instance üret
          //  services.AddScoped<IDeneme, Deneme>();//bir request boyunca ihtiyaç duyuldukça aynı insatneceı kullan
            services.AddScoped<IDeneme, DenemeYeni>();//bir request boyunca ihtiyaç duyuldukça aynı insatneceı kullan
            services.AddScoped<IDersRepository, DersRepository>();
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
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Kisi}/{action=Index}/{id?}");
            });
        }
    }
}
