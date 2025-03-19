using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCGamersApp.Data;
using MVCGamersApp.Models;

namespace MVCGamersApp.Controllers
{
    public class GamerPlaysController : Controller
    {
        private readonly MVCGamersAppContext _context;

        public GamerPlaysController(MVCGamersAppContext context)
        {
            _context = context;
        }

        // GET: GamerPlays
        public async Task<IActionResult> Index()
        {
            var mVCGamersAppContext = _context.GamerPlays.Include(g => g.Game).Include(g => g.Gamer);
            return View(await mVCGamersAppContext.ToListAsync());
        }

        // GET: GamerPlays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamerPlays = await _context.GamerPlays
                .Include(g => g.Game)
                .Include(g => g.Gamer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gamerPlays == null)
            {
                return NotFound();
            }

            return View(gamerPlays);
        }

        // GET: GamerPlays/Create
        public IActionResult Create()
        {
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "Id");
            ViewData["GamerId"] = new SelectList(_context.Gamer, "Id", "Id");
            return View();
        }

        // POST: GamerPlays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GamerId,GameId,HoursPlayed")] GamerPlays gamerPlays)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gamerPlays);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "Id", gamerPlays.GameId);
            ViewData["GamerId"] = new SelectList(_context.Gamer, "Id", "Id", gamerPlays.GamerId);
            return View(gamerPlays);
        }

        // GET: GamerPlays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamerPlays = await _context.GamerPlays.FindAsync(id);
            if (gamerPlays == null)
            {
                return NotFound();
            }
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "Id", gamerPlays.GameId);
            ViewData["GamerId"] = new SelectList(_context.Gamer, "Id", "Id", gamerPlays.GamerId);
            return View(gamerPlays);
        }

        // POST: GamerPlays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GamerId,GameId,HoursPlayed")] GamerPlays gamerPlays)
        {
            if (id != gamerPlays.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gamerPlays);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GamerPlaysExists(gamerPlays.Id))
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
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "Id", gamerPlays.GameId);
            ViewData["GamerId"] = new SelectList(_context.Gamer, "Id", "Id", gamerPlays.GamerId);
            return View(gamerPlays);
        }

        // GET: GamerPlays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamerPlays = await _context.GamerPlays
                .Include(g => g.Game)
                .Include(g => g.Gamer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gamerPlays == null)
            {
                return NotFound();
            }

            return View(gamerPlays);
        }

        // POST: GamerPlays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gamerPlays = await _context.GamerPlays.FindAsync(id);
            if (gamerPlays != null)
            {
                _context.GamerPlays.Remove(gamerPlays);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GamerPlaysExists(int id)
        {
            return _context.GamerPlays.Any(e => e.Id == id);
        }
    }
}
