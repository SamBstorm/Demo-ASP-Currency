using Demo_Mockup_Currency.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace Demo_ASP_Currency
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Localization
            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                string[] supportedCultures = new string[]
                {
                    "en-US",    //Si en-US, alors le pattern des input de prix sera :  pattern="^\d*\.{0,1}\d*$"
                    "fr-BE"     //Si fr-BE, alors le pattern des input de prix sera :  pattern="^\d*,{0,1}\d*$"
                };
                string defaultCulture = supportedCultures[1];   //Choisir la culture (c'est la d�finision du format selon la r�gion)
                options.SetDefaultCulture(defaultCulture);      //D�finir la culture par d�faut
                //options.AddSupportedCultures(supportedCultures);      //Si multilingue, d�finir les cultures support�es par le site
                //options.AddSupportedUICultures(supportedCultures);
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Service Donn�es :
            builder.Services.AddScoped<ProductService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            //Localization
            app.UseRequestLocalization();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}