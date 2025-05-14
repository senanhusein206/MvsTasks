using FinallySimulation.BL.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinallySimulation.MVC.Controllers
{
    public class HomeController : Controller
    {

        private readonly OurCauseService ourCauseService;
        public HomeController()
        {
            ourCauseService = new OurCauseService();
        }
        public IActionResult Index()
        {
            var model = ourCauseService.GetAllOurCauses();
            return View(model);
        }
    }
}
