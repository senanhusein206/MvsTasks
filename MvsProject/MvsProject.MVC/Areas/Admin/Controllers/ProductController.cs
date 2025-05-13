using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using MvsProject.BL;
using MvsProject.BL.Exceptions;
using MvsProject.BL.Services;
using MvsProject.DAL.Models;

namespace MvsProject.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {

        private readonly ProductService productService;
        public ProductController()
        {
            productService = new ProductService();
        }

        [HttpGet]
        public IActionResult Index()
        {
          var mod=  productService.GetAllProducts();
            return View(mod);
        }

        [HttpGet]
        public IActionResult Info(int id) 
        { 
        var model=productService.GetProductById(id);
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductVM prop)
        {
            if (!ModelState.IsValid)
            {
                throw new ProductException("Yooooooxxxxxxxxxxxxxx");
            }
            productService.Create(prop);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var mdodel=productService.GetProductById(id);
            return View(mdodel);
        }

        [HttpPost]

        public IActionResult Update(int id, ProductVM prop)
        {
            productService.Update(id, prop);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            productService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
