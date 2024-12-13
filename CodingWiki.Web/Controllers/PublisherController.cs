using CodingWiki.DataAccess.Data;
using CodingWiki.Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodingWiki.Web.Controllers
{
    public class PublisherController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PublisherController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Publisher> objList = _db.Publishers.ToList();
            return View(objList);
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            Publisher obj = new();
            if (id == null || id == 0)
            {
                //create
                return View(obj);
            }
            //edit
            obj = await _db.Publishers.FirstOrDefaultAsync(u => u.Publisher_Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Publisher obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Publisher_Id == 0)
                {
                    //create
                    await _db.Publishers.AddAsync(obj);
                }
                else
                {
                    //update
                    _db.Publishers.Update(obj);
                }
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            Publisher obj = new();
            obj = await _db.Publishers.FirstOrDefaultAsync(u => u.Publisher_Id == id);
            if (id == null)
            {
                return NotFound();
            }
            _db.Publishers.Remove(obj);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
