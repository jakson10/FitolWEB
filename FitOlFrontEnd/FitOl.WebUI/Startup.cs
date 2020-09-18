using FitOl.WebUI.ApiServices.Concrete;
using FitOl.WebUI.ApiServices.Interfaces;
using FitOl.WebUI.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace FitOl.WebUI
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
            services.AddHttpContextAccessor();
            services.AddSession();

            services.AddHttpClient<IImageApiService, ImageApiManager>();
            services.AddHttpClient<IFoodApiService, FoodApiManager>();
            services.AddHttpClient<IMovementApiService, MovementApiManager>();
            services.AddHttpClient<INutritionListApiService, NutritionListApiManager>();
            services.AddHttpClient<IAuthApiService, AuthApiManager>();
            services.AddHttpClient<ISportListApiService, SportListApiManager>();
            services.AddHttpClient<IUserApiService, UserApiManager>();
            services.AddSingleton<SessionHelper>();



            services.AddAuthentication(options =>
            {
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
                .AddCookie(opt =>
                {
                opt.Cookie.Name = "FitOlCokkie";
                opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict; //strict yaparsan baska sayfayla cookie paylasýlmaz
                opt.Cookie.HttpOnly = true;  //cookie bilgisine ulasamaz document.write ile
                opt.ExpireTimeSpan = TimeSpan.FromDays(20); //ne kadar süre ayakta kalýcak
                opt.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest; //istek neyse o sekýlde davran http yada https
                opt.LoginPath = "/Security/Login";
                opt.LogoutPath = "/Security/Logout";
                opt.AccessDeniedPath = "/Security/AccessDenied";
                opt.SlidingExpiration = true;
            });

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
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHttpsRedirection();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Calculator}/{id?}");
            });
        }
    }
}
