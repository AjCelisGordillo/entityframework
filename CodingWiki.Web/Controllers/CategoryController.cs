using CodingWiki.DataAccess.Data;
using CodingWiki.Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodingWiki.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Category> objList = _db.Categories.ToList();
            return View(objList);
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            Category obj = new();
            if(id == null || id == 0)
            {
                //create
                return View(obj);
            }
            //edit
            obj = await _db.Categories.FirstOrDefaultAsync(u => u.Category_Id == id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);   
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Category obj) 
        {
            if(ModelState.IsValid)
            {
                if(obj.Category_Id == 0)
                {
                    //create
                    await _db.Categories.AddAsync(obj);
                }
                else
                {
                    //update
                    _db.Categories.Update(obj);
                }
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            Category obj = new();
            obj = await _db.Categories.FirstOrDefaultAsync(u => u.Category_Id == id);
            if (id == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CreateMultiple2()
        {
            for(int i = 1; i <= 2; i++)
            {
                await _db.Categories.AddAsync(new Category { CategoryName = Guid.NewGuid().ToString() });
            }
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CreateMultiple5()
        {
            for (int i = 1; i <= 5; i++)
            {
                await _db.Categories.AddAsync(new Category { CategoryName = Guid.NewGuid().ToString() });
            }
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RemoveMultiple2()
        {
            IEnumerable<Category> categories = _db.Categories.OrderByDescending(u => u.Category_Id).Take(2).ToList();
            _db.Categories.RemoveRange(categories);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RemoveMultiple5()
        {
            IEnumerable<Category> categories = _db.Categories.OrderByDescending(u => u.Category_Id).Take(5).ToList();
            _db.Categories.RemoveRange(categories);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
