using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using MVCSimilotion1.BL.Services;
using MVCSimilotion1.BL.ViewsModels;
using MVCSimilotion1.DAL.Models;

namespace MVCSimilotion1.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChooseProgramController : Controller
    {
        private readonly ChooseProgramService programService;
        public ChooseProgramController(ChooseProgramService chooseProgramService)
        {
            programService = chooseProgramService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = programService.GetAllChoosePrograms();
            return View(model);
        }

        [HttpGet]
        public IActionResult Info(int id)
        {
            var model = programService.GetChooseProgramById(id);
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateProgramVM program)
        {
            programService.Create(program);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            CreateProgramVM modeVLM = new CreateProgramVM();

            var model = programService.GetChooseProgramById(id);
            modeVLM.Name = model.Name;
            modeVLM.Description = model.Description;

            return View(modeVLM);
        }

        [HttpPost]
        public IActionResult Update(int id, CreateProgramVM p)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("@");
            }
            programService.Update(id, p);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            programService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
