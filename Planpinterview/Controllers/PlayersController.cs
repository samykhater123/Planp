using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Planpinterview.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Internal;
using System.Diagnostics;

namespace Planpinterview.Controllers
{
    public class PlayersController : Controller
    {
        private readonly appdbcontext _context;

        public PlayersController(appdbcontext context)
        {
            _context = context;
        }

        // GET: Players
        public async Task<IActionResult> Index()
        {
            var appdbcontext = _context.players.Include(p => p.categprogram);
            return View(await appdbcontext.ToListAsync());
        }
       
        public async Task<IActionResult> Results()
        {
            ViewBag.totalmony = _context.players.Select(x=>x.monyvalue).Sum();
            var appdbcontext = _context.players.Include(p => p.categprogram);
            return View(await appdbcontext.ToListAsync());
        }

        public async Task<IActionResult> FilterResults(DateTime start,DateTime end)
        {

            var appdbcontext = _context.players.Where(x => x.date >= start && x.date <= end||x.date==start);

              
            return View(await appdbcontext.ToListAsync());
        }


        // GET: Players/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.players
                .Include(p => p.categprogram)
                .FirstOrDefaultAsync(m => m.id == id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }
        [HttpGet]
        public ActionResult<double> getmonyvalueAsync(int? id)
        {
            //IEnumerable<double> mony = from m in _db.categprogram
            //           .Where(x => x.id == id)
            //           select m.monyvalue;
            if (id==null)
            {
                return BadRequest();
            }
            var mm = _context.categprogram.Where(x => x.id == id).FirstOrDefault().monyvalue;

            return  mm;
        }

        // GET: Players/Create
        public IActionResult Create()
        {
            ViewData["categprogramid"] = new SelectList(_context.categprogram, "id", "name");
            return View();
        }

        // POST: Players/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,address,date,categprogramid,monyvalue")] Player player)
        {
            if (ModelState.IsValid)
            {
                _context.Add(player);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["categprogramid"] = new SelectList(_context.categprogram, "id", "name", player.categprogramid);
            return View(player);
        }

        // GET: Players/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }
            ViewData["categprogramid"] = new SelectList(_context.categprogram, "id", "name", player.categprogramid);
            return View(player);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,address,date,categprogramid,monyvalue")] Player player)
        {
            if (id != player.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(player);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerExists(player.id))
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
            ViewData["categprogramid"] = new SelectList(_context.categprogram, "id", "name", player.categprogramid);
            return View(player);
        }

        // GET: Players/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.players
                .Include(p => p.categprogram)
                .FirstOrDefaultAsync(m => m.id == id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var player = await _context.players.FindAsync(id);
            _context.players.Remove(player);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayerExists(int id)
        {
            return _context.players.Any(e => e.id == id);
        }
    }
}
