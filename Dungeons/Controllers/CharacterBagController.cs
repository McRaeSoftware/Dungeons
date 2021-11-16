using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dungeons.Data;
using Dungeons.Models;

namespace Dungeons.Controllers
{
    public class CharacterBagController : Controller
    {
        private readonly DungeonsDBContext _context;

        public CharacterBagController(DungeonsDBContext context)
        {
            _context = context;
        }

        // GET: CharacterBags
        public async Task<IActionResult> Index()
        {
            return View(await _context.CharacterBag.ToListAsync());
        }

        // GET: CharacterBags/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var characterBag = await _context.CharacterBag
                .FirstOrDefaultAsync(m => m.CharacterBagID == id);
            if (characterBag == null)
            {
                return NotFound();
            }

            return View(characterBag);
        }

        // GET: CharacterBags/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CharacterBags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CharacterBagID,CharacterCode,Gold,Silver,Copper")] CharacterBag characterBag)
        {
            if (ModelState.IsValid)
            {
                _context.Add(characterBag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(characterBag);
        }

        // GET: CharacterBags/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var characterBag = await _context.CharacterBag.FindAsync(id);
            if (characterBag == null)
            {
                return NotFound();
            }
            return View(characterBag);
        }

        // POST: CharacterBags/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CharacterBagID,CharacterCode,Gold,Silver,Copper")] CharacterBag characterBag)
        {
            if (id != characterBag.CharacterBagID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(characterBag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharacterBagExists(characterBag.CharacterBagID))
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
            return View(characterBag);
        }

        // GET: CharacterBags/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var characterBag = await _context.CharacterBag
                .FirstOrDefaultAsync(m => m.CharacterBagID == id);
            if (characterBag == null)
            {
                return NotFound();
            }

            return View(characterBag);
        }

        // POST: CharacterBags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var characterBag = await _context.CharacterBag.FindAsync(id);
            _context.CharacterBag.Remove(characterBag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CharacterBagExists(int id)
        {
            return _context.CharacterBag.Any(e => e.CharacterBagID == id);
        }
    }
}
