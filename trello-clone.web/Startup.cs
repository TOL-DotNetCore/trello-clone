using Amazon.S3;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trello_clone.web.Data;
using trello_clone.web.Entities;
using trello_clone.web.Services;
using trello_clone.web.Services.IServices;

namespace trello_clone.web
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
            services.AddScoped<IBoardService, BoardService>();
            services.AddScoped<IListService, ListService>();
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<IOrganizationService, OrganizationService>();
            services.AddScoped<ITrelloTokenService, TrelloTokenService>();
            services.AddScoped<IApplicationUserService, ApplicationUserService>();

            services.AddHttpClient();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddDefaultTokenProviders().AddDefaultUI()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAuthentication()
                .AddFacebook(options =>
                {
                    options.AppId = Configuration.GetValue<string>("Facebook:AppId");
                    options.AppSecret = Configuration.GetValue<string>("Facebook:AppSecret");
                }
                )
                .AddGoogle(options =>
                {
                    options.ClientId = Configuration.GetValue<string>("Google:ClientId");
                    options.ClientSecret = Configuration.GetValue<string>("Google:ClientSecret");
                });

            services.AddMvc();
            services.AddHttpContextAccessor();

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
