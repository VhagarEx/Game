using Game.Data;
using Game.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Game.Controllers
{
    public class GamersController : Controller
    {
        private readonly GameContext _context;

        public GamersController(GameContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string GamerRank, string searchString)
        {
            if (_context.Gamer == null)
            {
                return Problem("Entity set 'GameContext.Gamer' is null.");
            }

            IQueryable<string> rankQuery = from m in _context.Gamer
                                           orderby m.Rank
                                           select m.Rank;

            var gamersQuery = from m in _context.Gamer
                              select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                gamersQuery = gamersQuery.Where(s => s.Name.Contains(searchString) ||
                                                   s.Surname.Contains(searchString) ||
                                                   (s.Rank != null && s.Rank.Contains(searchString)));
            }

            if (!string.IsNullOrEmpty(GamerRank))
            {
                gamersQuery = gamersQuery.Where(x => x.Rank == GamerRank);
            }

            var GamerRankVM = new GamerRankViewModel
            {
                Rank = new SelectList(await rankQuery.Distinct().ToListAsync()),
                Gamers = await gamersQuery.ToListAsync(),
                GamerRank = GamerRank,
                SearchString = searchString
            };

            return View(GamerRankVM);
        }

        // GET: Gamers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamer = await _context.Gamer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gamer == null)
            {
                return NotFound();
            }

            return View(gamer);
        }

        // GET: Gamers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gamers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Surname,Name,DataRegistr,Email,Paswd,Rank")] Gamer gamer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gamer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gamer);
        }

        // GET: Gamers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamer = await _context.Gamer.FindAsync(id);
            if (gamer == null)
            {
                return NotFound();
            }
            return View(gamer);
        }

        // POST: Gamers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Surname,Name,DataRegistr,Email,Paswd,Rank")] Gamer gamer)
        {
            if (id != gamer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gamer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GamerExists(gamer.Id))
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
            return View(gamer);
        }

        // GET: Gamers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamer = await _context.Gamer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gamer == null)
            {
                return NotFound();
            }

            return View(gamer);
        }

        // POST: Gamers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gamer = await _context.Gamer.FindAsync(id);
            if (gamer != null)
            {
                _context.Gamer.Remove(gamer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GamerExists(int id)
        {
            return _context.Gamer.Any(e => e.Id == id);
        }
    }
}
