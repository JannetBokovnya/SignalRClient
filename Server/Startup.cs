using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Server.Hubs;

namespace Server
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();

            //���������� �������, ������� ���������� CORS (Cross Origin Resource Sharing).
            //��������� ������� �� ���������� � ������ ������(��� ������) � ����������, ������� ��������� �� ������� ������
            //��� ����������� �������� CORS � ���������� � ������ ConfigureServices ���������� ����� services.AddCors().
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            //����� ������������� CORS ��� ��������� ������� � ������ Configure ���������� ����� UseCors().
            //��� ��������� ������������ ���� ����� ���������� �������, � ������� ���������� ������ CorsPolicyBuilder. 
            //� � ������� ����� ������� ����� ��������� ��������� CORS.
            //� ������� ������ AllowAnyOrigin() �� ���������, ��� ���������� ����� ������������ ������� �� ���������� �� ����� �������.
            app.UseCors(policy =>
            {
                policy
                    .SetIsOriginAllowed(origin => true)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });

                endpoints.MapHub<MessageHub>("/messages");
            });
        }
    }
}
