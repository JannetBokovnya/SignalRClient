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

            //используем технику, которая называется CORS (Cross Origin Resource Sharing).
            //выполняем запросы из приложения с одного адреса(или домена) к приложению, которое размещено по другому адресу
            //Для подключения сервисов CORS в приложение в методе ConfigureServices вызывается метод services.AddCors().
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
            //Чтобы задействовать CORS для обработки запроса в методе Configure вызывается метод UseCors().
            //Для настройки конфигурации этот метод использует делегат, в который передается объект CorsPolicyBuilder. 
            //И с помощью этого объекта можно выполнить настройку CORS.
            //С помощью метода AllowAnyOrigin() мы указываем, что приложение может обрабатывать запросы от приложений по любым адресам.
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
