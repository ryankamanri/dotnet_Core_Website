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
using WebApplication1.Data;

namespace WebApplication1
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
            services.AddRazorPages();
            string[] corsUrls = Configuration["corsUrls"].ToString().Split(',');
            //跨域配置
            //services.AddCors(options => options.AddPolicy("cors",
            //builder => builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()));
            //AllowAnyMethod允许跨域策略允许所有的方法：GET/POST/PUT/DELETE 等方法  如果进行限制需要 AllowAnyMethod("GET","POST") 这样来进行访问方法的限制
            //AllowAnyHeader允许任何的Header头部标题    有关头部标题如果不设置就不会进行限制
            //AllowAnyOrigin 允许任何来源，一般不会设定所有源都可以访问，而是只开放给对应的ip使用的。  
            //AllowCredentials 设置凭据来源 不可与AllowAnyOrigin 一起同时使用,否则会报错：
            //限制为指定的域才可访问，可加上.WithOrigins("www.xxx.com","www.xx2.com") 
            services.AddCors(p => p.AddPolicy("cors",
                policy => policy.WithOrigins(corsUrls).AllowAnyMethod().AllowAnyHeader().AllowCredentials()));
            services.AddDbContext<WebApplication1Context>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("WebApplication1Context")));
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors("cors");
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
