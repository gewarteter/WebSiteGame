using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcGame.Data;
using MvcGame.Models;

namespace MvcGame.Controllers
{
    public class LevelController : Controller
    {
        private readonly LevelsContext _context;

        public LevelController(LevelsContext context)
        {
            _context = context;
        }

        // GET: Level
        public async Task<IActionResult> Index()
        {
            return View(await _context.Levels.ToListAsync());
        }

        // GET: Level/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var levels = await _context.Levels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (levels == null)
            {
                return NotFound();
            }

            return View(levels);
        }

        // GET: Level/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Level/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Mode,Role")] Levels levels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(levels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(levels);
        }

        // GET: Level/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var levels = await _context.Levels.FindAsync(id);
            if (levels == null)
            {
                return NotFound();
            }
            return View(levels);
        }

        // POST: Level/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Mode,Role")] Levels levels)
        {
            if (id != levels.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(levels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LevelsExists(levels.Id))
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
            return View(levels);
        }

        // GET: Level/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var levels = await _context.Levels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (levels == null)
            {
                return NotFound();
            }

            return View(levels);
        }

        // POST: Level/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var levels = await _context.Levels.FindAsync(id);
            if (levels != null)
            {
                _context.Levels.Remove(levels);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LevelsExists(int id)
        {
            return _context.Levels.Any(e => e.Id == id);
        }
    }
}
