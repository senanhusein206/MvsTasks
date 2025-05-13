using Microsoft.AspNetCore.Mvc;
using MvsProject.BL.Services;

namespace MvsProject.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductService productService;
        public HomeController()
        {
            productService = new ProductService();
        }
        public IActionResult Index()
        {
           var m= productService.GetAllProducts();
                
            return View(m);
        }
    }
}
