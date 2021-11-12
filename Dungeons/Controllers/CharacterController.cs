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
    public class CharacterController : Controller
    {
        private readonly DungeonsDBContext _database;

        public CharacterController(DungeonsDBContext context)
        {
            _database = context;
        }

        // GET: Character
        public async Task<IActionResult> Index()
        {
            return View(await _database.Character.ToListAsync());
        }

        // GET: Character/DisplayCharacter/5
        public async Task<IActionResult> DisplayCharacter(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _database.Character.FirstOrDefaultAsync(m => m.Character_ID == id);
            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // GET: Character/CreateCharacter
        public IActionResult CreateCharacter()
        {
            return View();
        }

        // POST: Character/CreateCharacter
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCharacter([Bind("Character_ID,User_ID,Code,Name,Alignment,Experience,Level,RaceName,ClassName,MaxHealth,CurrentHealth,Strength,Dexterity,Constitution,Intelligence,Wisdom,Charisma,SavingThrows,Proficiencies,Languages")] Character character)
        {
            if (ModelState.IsValid)
            {
                _database.Add(character);
                await _database.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(character);
        }

        // GET: Character/EditCharacter/5
        public async Task<IActionResult> EditCharacter(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _database.Character.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }
            return View(character);
        }

        // POST: Character/EditCharacter/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCharacter(int id, [Bind("Character_ID,User_ID,Code,Name,Alignment,Experience,Level,RaceName,ClassName,MaxHealth,CurrentHealth,Strength,Dexterity,Constitution,Intelligence,Wisdom,Charisma,SavingThrows,Proficiencies,Languages")] Character character)
        {
            if (id != character.Character_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _database.Update(character);
                    await _database.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharacterExists(character.Character_ID))
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
            return View(character);
        }

        // GET: Character/DeleteCharacter/5
        public async Task<IActionResult> DeleteCharacter(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _database.Character.FirstOrDefaultAsync(m => m.Character_ID == id);
            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // POST: Character/DeleteCharacter/5
        [HttpPost, ActionName("DeleteCharacter")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var character = await _database.Character.FindAsync(id);
            _database.Character.Remove(character);
            await _database.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CharacterExists(int id)
        {
            return _database.Character.Any(e => e.Character_ID == id);
        }
    }
}
