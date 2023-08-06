using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using web_shop.Areas.Identity.Data;
using web_shop.Data;
namespace web_shop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("Default") ?? throw new InvalidOperationException("Connection string 'Default' not found.");

            // servis za kreiranje resursa objekta klase konteksta
            builder.Services.AddDbContext<AppDbContex>(options => options.UseSqlServer(connectionString));

            // servis koji kaze kako je klasa AppUser glavna za identifikaciju korisnika 
            builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<AppDbContex>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            // kreiranje servisa za koristenje razor page opcija
            builder.Services.AddRazorPages();

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
            app.UseAuthentication();;

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.Run();
        }
    }
}