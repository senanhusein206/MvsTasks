using FinallySimulation.BL.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinallySimulation.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly OurCauseService ourCauseService;
        public DashboardController()
        {
            ourCauseService = new OurCauseService();
        }
        public IActionResult Index()
        {
           var model= ourCauseService.GetAllOurCauses();
            return View(model);
        }
    }
}
