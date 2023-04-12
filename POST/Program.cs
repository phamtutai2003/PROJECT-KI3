﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using POST.Data;

namespace POST
{

    public class Program
    {

        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<POSTContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("POSTContext") ));
          
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
             name: "areas",
             pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
           );
                endpoints.MapControllerRoute(
                 name: "default",
                     pattern: "{controller=Home}/{action=Index}/{id?}");
            });

        
            app.Run();
            builder.Services.AddRazorPages().AddRazorRuntimeCompilation();



        }
    }
}