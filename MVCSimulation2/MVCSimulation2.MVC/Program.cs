using Microsoft.EntityFrameworkCore;
using MVCSimulation2.BL.Services;
using MVCSimulation2.DAL.Contexts;

namespace MVCSimulation2.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string connection = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connection));
            builder.Services.AddScoped<CollectionService>();

            builder.Services.AddControllersWithViews();

            var app = builder.Build();
            app.UseStaticFiles();
            app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Collection}/{action=Index}/{id?}"
          );
            app.MapControllerRoute(
                name:"Default",
                pattern:"{Controller=Home}/{Action=Index}"
                
                );

         

            app.Run();
        }
    }
}
