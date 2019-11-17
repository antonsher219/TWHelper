using Domain.Models.Identity;
using Infrastructure;

using System;
using System.Text;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using TWHelp.Models.Infrastructure;
using System.Net.WebSockets;

namespace TWHelp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //https://www.learnrazorpages.com/advanced/areas#targetText=The%20Areas%20feature%20in%20Razor,%2C%20production%2C%20and%20so%20on.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services
                .AddIdentity<User, IdentityRole<long>>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequiredLength = 6;
                })
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IEmailSender, EmailSender>();

            //note: it's not a default AuthenticationSchemes
            services
                .AddAuthentication()
                .AddJwtBearer("JwtBearer", jwtBearerOptions =>
                {
                    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = "WishlistApp",
                        ValidateIssuer = true,

                        ValidAudience = "WishlistAppClient",
                        ValidateAudience = true,

                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Security:Tokens:Jwt:JwtToken"])),
                        ValidateIssuerSigningKey = true,

                        ClockSkew = TimeSpan.FromSeconds(5),
                        ValidateLifetime = true,
                    };
                })
                .AddGoogle(googleOptions =>
                {
                    googleOptions.ClientSecret = Configuration["Security:Tokens:GoogleLocal:ClientSecret"];
                    googleOptions.ClientId = Configuration["Security:Tokens:GoogleLocal:ClientId"];
                })
                .AddFacebook(facebookOptions =>
                {
                    facebookOptions.AppSecret = Configuration["Security:Tokens:FacebookLocal:AppSecret"];
                    facebookOptions.AppId = Configuration["Security:Tokens:FacebookLocal:AppId"];
                });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddRazorPagesOptions(options => 
                {
                    options.AllowAreas = true;
                    options.Conventions.AddAreaPageRoute("Home", "/Index", "");
                });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();
            app.UseWebSockets();
            app.UseMvc();

            //seed database
            ApplicationDbContext.CreateAdminAccount(app.ApplicationServices, Configuration).Wait();
        }
    }
}

//  recreate database
//services.BuildServiceProvider().GetService<ApplicationDbContext>().Database.EnsureDeleted();
//services.BuildServiceProvider().GetService<ApplicationDbContext>().Database.Migrate();
