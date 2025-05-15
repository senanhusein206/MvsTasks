using Microsoft.EntityFrameworkCore;
using MVCSimilotion1.BL.Services;
using MVCSimilotion1.DAL.Contexts;

namespace MVCSimilotion1.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string? connectionStr = builder.Configuration.GetConnectionString("Default");
            
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionStr));
            builder.Services.AddScoped<ChooseProgramService>();
            var app = builder.Build();
            app.UseStaticFiles();
            app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=ChooseProgram}/{action=Index}/{id?}"
          );
            app.MapControllerRoute(
                name:"Default",
                pattern:"{Controller=Home}/{Action=Index}"
                );

           

            app.Run();
        }
    }
}
