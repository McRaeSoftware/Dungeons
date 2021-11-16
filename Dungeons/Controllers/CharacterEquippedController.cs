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
    public class CharacterEquippedController : Controller
    {
        private readonly DungeonsDBContext _context;

        public CharacterEquippedController(DungeonsDBContext context)
        {
            _context = context;
        }

        // GET: CharacterEquipped
        public async Task<IActionResult> Index()
        {
            return View(await _context.CharacterEquipped.ToListAsync());
        }

        // GET: CharacterEquipped/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var characterEquipped = await _context.CharacterEquipped
                .FirstOrDefaultAsync(m => m.CharacterEquippedID == id);
            if (characterEquipped == null)
            {
                return NotFound();
            }

            return View(characterEquipped);
        }

        // GET: CharacterEquipped/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CharacterEquipped/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CharacterEquippedID,CharacterCode,ArmourClass,ArmourName,MainHand,OffHand")] CharacterEquipped characterEquipped)
        {
            if (ModelState.IsValid)
            {
                _context.Add(characterEquipped);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(characterEquipped);
        }

        // GET: CharacterEquipped/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var characterEquipped = await _context.CharacterEquipped.FindAsync(id);
            if (characterEquipped == null)
            {
                return NotFound();
            }
            return View(characterEquipped);
        }

        // POST: CharacterEquipped/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CharacterEquippedID,CharacterCode,ArmourClass,ArmourName,MainHand,OffHand")] CharacterEquipped characterEquipped)
        {
            if (id != characterEquipped.CharacterEquippedID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(characterEquipped);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharacterEquippedExists(characterEquipped.CharacterEquippedID))
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
            return View(characterEquipped);
        }

        // GET: CharacterEquipped/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var characterEquipped = await _context.CharacterEquipped
                .FirstOrDefaultAsync(m => m.CharacterEquippedID == id);
            if (characterEquipped == null)
            {
                return NotFound();
            }

            return View(characterEquipped);
        }

        // POST: CharacterEquipped/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var characterEquipped = await _context.CharacterEquipped.FindAsync(id);
            _context.CharacterEquipped.Remove(characterEquipped);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CharacterEquippedExists(int id)
        {
            return _context.CharacterEquipped.Any(e => e.CharacterEquippedID == id);
        }
    }
}
