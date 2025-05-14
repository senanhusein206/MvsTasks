using FinallySimulation.BL.Services;
using FinallySimulation.BL.ViewModels;
using FinallySimulation.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinallySimulation.MVC.Areas.Admin.Controllers;
[Area("Admin")]
public class OurCauseController : Controller
{
    private readonly OurCauseService ourCauseService;
    public OurCauseController()
    {
        ourCauseService = new OurCauseService();
    }

    [HttpGet]
    public IActionResult Index()
    {
        var model = ourCauseService.GetAllOurCauses();
        return View(model);
    }

    [HttpGet]
    public IActionResult Info(int id)
    {
        var model = ourCauseService.GetOurCauseById(id);
        return View(model);
    }


    [HttpGet]

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(CreateOurVM our)
    {
        ourCauseService.Create(our);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        var model = ourCauseService.GetOurCauseById(id);
        CreateOurVM model2 = ourCauseService.ReMap(model);
        return View(model2);
    }

    [HttpPost]
    public IActionResult Update(int id, CreateOurVM our)
    {
        ourCauseService.Update(id, our);
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public IActionResult Delete(int id)
    {
        ourCauseService.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}
