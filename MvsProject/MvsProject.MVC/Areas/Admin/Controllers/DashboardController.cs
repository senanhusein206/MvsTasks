using Microsoft.AspNetCore.Mvc;
using MvsProject.BL.Services;

namespace MvsProject.MVC.Areas.Admin.Controllers;
[Area("Admin")]

public class DashboardController : Controller
{
    private readonly ProductService productService;
    public DashboardController()
    {
        productService= new ProductService();
    }
    public IActionResult Index()
    {
       var model= productService.GetAllProducts();
        return View(model);
    }
}
