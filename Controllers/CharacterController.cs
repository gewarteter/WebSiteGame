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
    public class CharacterController : Controller
    {
        private readonly CharacterContext _context;

        public CharacterController(CharacterContext context)
        {
            _context = context;
        }

        // GET: Character
        public async Task<IActionResult> Index()
        {
            return View(await _context.Characters.ToListAsync());
        }

        // GET: Character/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var characters = await _context.Characters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (characters == null)
            {
                return NotFound();
            }

            return View(characters);
        }

        // GET: Character/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Character/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Attribute,Complexity")] Characters characters)
        {
            if (ModelState.IsValid)
            {
                _context.Add(characters);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(characters);
        }

        // GET: Character/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var characters = await _context.Characters.FindAsync(id);
            if (characters == null)
            {
                return NotFound();
            }
            return View(characters);
        }

        // POST: Character/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Attribute,Complexity")] Characters characters)
        {
            if (id != characters.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(characters);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharactersExists(characters.Id))
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
            return View(characters);
        }

        // GET: Character/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var characters = await _context.Characters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (characters == null)
            {
                return NotFound();
            }

            return View(characters);
        }

        // POST: Character/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var characters = await _context.Characters.FindAsync(id);
            if (characters != null)
            {
                _context.Characters.Remove(characters);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CharactersExists(int id)
        {
            return _context.Characters.Any(e => e.Id == id);
        }
    }
}
