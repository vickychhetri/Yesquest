using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Yesquest.data;
using Yesquest.Models.vm;

namespace Yesquest.Controllers
{
    public class ItemTableController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ItemTableController(ApplicationDbContext db)
        {
            _db=db;
        }
        // GET: ItemTableController
        public ActionResult Index()
        {
            var obj = _db.Itemtable.Include(u=>u.Category).ToList(); 
            return View(obj);
        }

        // GET: ItemTableController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ItemTableController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ItemTableController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ItemTableController/Edit/5
        public ActionResult Edit(int id)
        {

            var obj = _db.Itemtable.FirstOrDefault(u => u.ItemId == id);

            if (obj == null)
            {
                return NotFound();
            }
            ItemVm itemVm = new()
            {
                Itemtable = obj,
                CategoryList = _db.ItemCategorytable.ToList().Select(
                    u => new SelectListItem
                    {
                        Text = u.CategoryName,
                        Value = u.CategoryId.ToString()
                    })
            };

            return View(itemVm);
        }

        // POST: ItemTableController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ItemVm itemVm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Itemtable.Update(itemVm.Itemtable);
                    _db.SaveChanges();

                }
         
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ec)
            {

                return Json(ec.Message);
            }
        }

        // GET: ItemTableController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ItemTableController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
