using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BooksStore.Models;

namespace BooksStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookDbContext _context;

        public BookController(BookDbContext context)
        {
            _context = context;
        }

        // GET: Book
        public async Task<IActionResult> Index()
        {
            //return _context.Books != null ?
             //   View(await _context.Books.ToListAsync()) :
             //   Problem("Entity set 'BookDbContext.Book' is Null.");
            return View(await _context.Books.ToListAsync());
        }

        

        // GET: Book/AddOrEdit
        public IActionResult AddOrEdit(int id = 0 )
        {
            if (id == 0)
            return View(new Book());
            else
            return View(_context.Books.Find(id));
        }

        // POST: Book/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("BookId,Title,Genre,Publisher,Author,Total_pages,Date")] Book book)
        {
            if (ModelState.IsValid)
            {

                if (book.BookId == 0)
                {
                    book.Date = DateTime.Now;
                    _context.Add(book);
                }
                else
                    
                _context.Update(book);
               await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }
        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Books == null)
            {
                return Problem("Entity set 'BookDbContext.Books'  is null.");
            }
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }
            var transaction = await _context.Books.FindAsync(id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
