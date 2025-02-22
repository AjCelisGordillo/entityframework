﻿using CodingWiki.DataAccess.Data;
using CodingWiki.Model.Models;
using CodingWiki.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CodingWiki.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Book> objList = _db.Books.Include(u => u.Publisher).ToList();
            //foreach (var obj in objList)
            //{
            //    // least eficcient
            //    //obj.Publisher = _db.Publishers.Find(obj.Publisher_Id);

            //    // more efficient
            //    _db.Entry(obj).Reference(u => u.Publisher).Load();
            //}
            return View(objList);
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            BookVM obj = new();

            obj.PublisherList = _db.Publishers.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Publisher_Id.ToString()
            });

            if (id == null || id == 0)
            {
                //create
                return View(obj);
            }
            //edit
            obj.Book = await _db.Books.FirstOrDefaultAsync(u => u.BookId == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(BookVM obj)
        {

            if (obj.Book.BookId == 0)
            {
                //create
                await _db.Books.AddAsync(obj.Book);
            }
            else
            {
                //update
                _db.Books.Update(obj.Book);
            }
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            BookDetail obj = new();

            //edit
            obj = _db.BookDetails.Include(u => u.Book).FirstOrDefault(u => u.Book_Id == id);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(BookDetail obj)
        {
            if (obj.BookDetail_Id == 0)
            {
                //create
                await _db.BookDetails.AddAsync(obj);
            }
            else
            {
                //update
                _db.BookDetails.Update(obj);
            }
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            Book obj = new();
            obj = await _db.Books.FirstOrDefaultAsync(u => u.BookId == id);
            if (id == null)
            {
                return NotFound();
            }
            _db.Books.Remove(obj);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
