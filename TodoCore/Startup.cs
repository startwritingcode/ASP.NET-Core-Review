using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Todo.Repositories;
using Todo.Services;
using Todo.Services.Factories;
using TodoCore.Data;
using TodoCore.Factories;

namespace TodoCore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ITodoListRepository, TodoListRepository>();
            services.AddScoped<ITodoItemRepository, TodoItemRepository>();
            services.AddScoped<ITodoListService, TodoListService>();
            services.AddScoped<ITodoItemService, TodoItemService>();
            services.AddScoped<ITodoListFactory, TodoListFactory>();
            services.AddScoped<ITodoItemFactory, TodoItemFactory>();
            services.AddScoped<ITodoListDtoFactory, TodoListDtoFactory>();
            services.AddScoped<ITodoItemDtoFactory, TodoItemDtoFactory>();

            var connection = @"Server=(localdb)\mssqllocaldb;Database=TodoCore;Trusted_Connection=True;";
            services.AddDbContext<TodoListContext>
                (options => options.UseSqlServer(connection, b => b.MigrationsAssembly("TodoCore")));

            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
