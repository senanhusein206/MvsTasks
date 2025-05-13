namespace CarVillaProject.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            var app = builder.Build();
            app.UseStaticFiles();
     
            app.MapControllerRoute(
                      name: "areas",
                      pattern: "{area:exists}/{controller=Car}/{action=Index}/{id?}"
                    );
            app.MapControllerRoute(
            name: "Default",
            pattern: "{Controller=Home}/{Action=Index}"
            );



            app.Run();
        }
    }
}