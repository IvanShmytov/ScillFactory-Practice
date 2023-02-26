using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ScillFactory_Practice.Extentions;
using ScillFactory_Practice.Models.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScillFactory_Practice
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
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services
                .AddDbContext<BlogContext>(options => options.UseSqlite(connection))
                .AddUnitOfWork()
                    .AddCustomRepository<User, UserRepository>()
                    .AddCustomRepository<Article, ArticlesRepository>()
                    .AddCustomRepository<Comment, CommentRepository>()
                    .AddCustomRepository<Tag, TagRepository>()
                    .AddCustomRepository<Role, RoleRepository>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Skillfactory-Practice", Version = "v1" });
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
              .AddCookie(options => //CookieAuthenticationOptions
                {
                  options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
              });
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ScillFactory-Practice v1"));
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
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Users}/{action=Authenticate}/{id?}");
                
            });
        }
    }
}
