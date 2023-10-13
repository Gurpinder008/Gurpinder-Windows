using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gurpinder_Windows.Data;
using Gurpinder_Windows.Models;

namespace Gurpinder_Windows.Controllers
{
    public class WindowsController : Controller
    {
        private readonly Gurpinder_WindowsContext _context;

        public WindowsController(Gurpinder_WindowsContext context)
        {
            _context = context;
        }

        // GET: Windows
        
        public async Task<IActionResult> Index(string windowStyle, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> styleQuery = from m in _context.Window
                                            orderby m.Style
                                            select m.Style;

            var windows = from m in _context.Window
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                windows = windows.Where(s => s.Name.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(windowStyle))
            {
                windows = windows.Where(x => x.Style == windowStyle);
            }

            var windowStyleVM = new WindowStyleViewModel
            {
                Styles = new SelectList(await styleQuery.Distinct().ToListAsync()),
                Windows = await windows.ToListAsync()
            };

            return View(windowStyleVM);
        }

        // GET: Windows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var window = await _context.Window
                .FirstOrDefaultAsync(m => m.Id == id);
            if (window == null)
            {
                return NotFound();
            }

            return View(window);
        }

        // GET: Windows/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Windows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Style,Material,Size,Price,Rating")] Window window)
        {
            if (ModelState.IsValid)
            {
                _context.Add(window);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(window);
        }

        // GET: Windows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var window = await _context.Window.FindAsync(id);
            if (window == null)
            {
                return NotFound();
            }
            return View(window);
        }

        // POST: Windows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Style,Material,Size,Price,Rating")] Window window)
        {
            if (id != window.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(window);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WindowExists(window.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(window);
        }

        // GET: Windows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var window = await _context.Window
                .FirstOrDefaultAsync(m => m.Id == id);
            if (window == null)
            {
                return NotFound();
            }

            return View(window);
        }

        // POST: Windows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var window = await _context.Window.FindAsync(id);
            _context.Window.Remove(window);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WindowExists(int id)
        {
            return _context.Window.Any(e => e.Id == id);
        }
    }
}
