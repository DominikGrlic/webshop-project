using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
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
            builder.Services.AddDbContext<AppDbContex>(
                options => options.UseSqlServer(connectionString));

            // servis koji kaze kako je klasa AppUser glavna za identifikaciju korisnika 
            builder.Services.AddDefaultIdentity<AppUser>(
                options => options.SignIn.RequireConfirmedAccount = false
                ).AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDbContex>();

            builder.Services.Configure<IdentityOptions>(
                options =>
                {
                    // osnovno postavke za lozinku (samo za vjezbu)
                    options.Password.RequireDigit = true;
                    options.Password.RequireUppercase =  false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                }

                );

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

            // postavke za rukovanje decimalnim vrijednostima
            var ci = new CultureInfo("de-De");
            ci.NumberFormat.NumberDecimalSeparator = ".";
            ci.NumberFormat.CurrencyDecimalSeparator = ".";

            app.UseRequestLocalization(
                new RequestLocalizationOptions
                {
                    DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(ci),
                    SupportedCultures = new List<CultureInfo> { ci },
                    SupportedUICultures = new List<CultureInfo> { ci }
                });

            app.UseRouting();
            app.UseAuthentication();;

            app.UseAuthorization();

            app.MapAreaControllerRoute(
                name: "Admin",
                areaName: "Admin",
                pattern: "admin/{controller}/{action}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.Run();
        }
    }
}