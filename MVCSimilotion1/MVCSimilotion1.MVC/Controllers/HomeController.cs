using Microsoft.AspNetCore.Mvc;
using MVCSimilotion1.BL.Services;
using MVCSimilotion1.DAL.Models;

namespace MVCSimilotion1.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ChooseProgramService programService;
        public HomeController(ChooseProgramService chooseProgramService)
        {
            programService = chooseProgramService;
        }
        public IActionResult Index()
        {
            var model = programService.GetAllChoosePrograms();
            return View(model);
        }
    }
}
