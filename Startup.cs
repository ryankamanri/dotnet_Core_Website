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
            //��������
            //services.AddCors(options => options.AddPolicy("cors",
            //builder => builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()));
            //AllowAnyMethod�����������������еķ�����GET/POST/PUT/DELETE �ȷ���  �������������Ҫ AllowAnyMethod("GET","POST") ���������з��ʷ���������
            //AllowAnyHeader�����κε�Headerͷ������    �й�ͷ��������������þͲ����������
            //AllowAnyOrigin �����κ���Դ��һ�㲻���趨����Դ�����Է��ʣ�����ֻ���Ÿ���Ӧ��ipʹ�õġ�  
            //AllowCredentials ����ƾ����Դ ������AllowAnyOrigin һ��ͬʱʹ��,����ᱨ��
            //����Ϊָ������ſɷ��ʣ��ɼ���.WithOrigins("www.xxx.com","www.xx2.com") 
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
