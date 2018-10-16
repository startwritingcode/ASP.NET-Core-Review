﻿using System;
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
using TodoCore.Data;

namespace TodoCore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ITodoListRepository, TodoListRepository>();
            services.AddTransient<ITodoItemRepository, TodoItemRepository>();
            services.AddTransient<ITodoListService, TodoListService>();
            services.AddTransient<ITodoListService, TodoListService>();

            services.AddMvc();

            var connection = @"Server=(localdb)\mssqllocaldb;Database=TodoCore;Trusted_Connection=True;";
            services.AddDbContext<TodoListContext>
                (options => options.UseSqlServer(connection, b => b.MigrationsAssembly("TodoCore")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
