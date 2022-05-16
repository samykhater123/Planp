using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Planpinterview.Models;

namespace Planpinterview.Controllers
{
    public class categprogramsController : Controller
    {
        private readonly appdbcontext _context;

        public categprogramsController(appdbcontext context)
        {
            _context = context;
        }

        // GET: categprograms
        public async Task<IActionResult> Index()
        {
            return View(await _context.categprogram.ToListAsync());
        }

        // GET: categprograms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categprogram = await _context.categprogram
                .FirstOrDefaultAsync(m => m.id == id);
            if (categprogram == null)
            {
                return NotFound();
            }

            return View(categprogram);
        }

        // GET: categprograms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: categprograms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,monyvalue")] categprogram categprogram)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categprogram);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categprogram);
        }

        public async Task<IActionResult> Createnewprogram([Bind("id,name,monyvalue")] categprogram categprogram)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categprogram);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categprogram);
        }

        // GET: categprograms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categprogram = await _context.categprogram.FindAsync(id);
            if (categprogram == null)
            {
                return NotFound();
            }
            return View(categprogram);
        }

        // POST: categprograms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,monyvalue")] categprogram categprogram)
        {
            if (id != categprogram.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categprogram);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!categprogramExists(categprogram.id))
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
            return View(categprogram);
        }

        // GET: categprograms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categprogram = await _context.categprogram
                .FirstOrDefaultAsync(m => m.id == id);
            if (categprogram == null)
            {
                return NotFound();
            }

            return View(categprogram);
        }

        // POST: categprograms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categprogram = await _context.categprogram.FindAsync(id);
            _context.categprogram.Remove(categprogram);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool categprogramExists(int id)
        {
            return _context.categprogram.Any(e => e.id == id);
        }
    }
}
