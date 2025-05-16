using Microsoft.AspNetCore.Mvc;
using MVCSimulation2.BL.Services;

namespace MVCSimulation2.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly CollectionService _collectionService;
        public HomeController(CollectionService collectionService)
        {
            _collectionService = collectionService;
        }
        public IActionResult Index()
        {
          var model=  _collectionService.GetAllCollections();
            return View(model);
        }
    }
}
