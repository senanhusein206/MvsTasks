using Microsoft.AspNetCore.Mvc;
using MVCSimulation2.BL.Services;
using MVCSimulation2.BL.ViewModels;
using MVCSimulation2.DAL.Models;

namespace MVCSimulation2.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CollectionController : Controller
    {
        private readonly CollectionService _collect;
        public CollectionController(CollectionService collection)
        {
            _collect = collection;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _collect.GetAllCollections();
            return View(model);
        }

        [HttpGet]
        public IActionResult Info(int id)
        {
           var model= _collect.GetCollectionById(id);
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateCollectionVM col)
        {
            if (!ModelState.IsValid)
            {
                return View(col);
            }
            _collect.Create(col);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            CreateCollectionVM col = new CreateCollectionVM();

            var model=_collect.GetCollectionById(id);

            col.Name = model.Name;
            col.Category = model.Category;
            col.NewCount = model.NewCount;
            col.OldCount = model.OldCount;
            return View(col);
        }

        [HttpPost]

        public IActionResult Update(CreateCollectionVM col,int id)
        {


            _collect.Update(col, id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _collect.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
