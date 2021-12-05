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
        public ICharacterDataAccess _database { get; set; }

        public CharacterController(ICharacterDataAccess database)
        {
            _database = database;
        }

        // GET: Character
        public async Task<IActionResult> Index(int userId)
        {
            return View(await _database.GetMyCharacterListAsync(userId));
        }

        // GET: Character/DisplayCharacter/5
        public async Task<IActionResult> DisplayCharacter(string code)
        {
            if (code == null)
            {
                return NotFound();
            }

            var character = await _database.GetCharacterByCode(code);

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
                await _database.CreateCharacter(character);
                return RedirectToAction(nameof(Index));
            }
            return View(character);
        }

        // GET: Character/EditCharacter/5
        public async Task<IActionResult> UpdateCharacter(string code)
        {
            if (code == null)
            {
                return NotFound();
            }

            var character = await _database.GetCharacterByCode(code);

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
        public async Task<IActionResult> UpdateCharacter(string code, [Bind("Code,User_ID,Name,Alignment,Experience,Level,RaceName,ClassName,MaxHealth,CurrentHealth,Strength,Dexterity,Constitution,Intelligence,Wisdom,Charisma,SavingThrows,Proficiencies,Languages")] Character character)
        {
            if (code != character.Code)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _database.UpdateCharacter(character);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharacterExists(character.Code))
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

        // GET: Character/EditCharacterBag
        public async Task<IActionResult> UpdateCharacterBag(string code)
        {
            if (code == null)
            {
                return NotFound();
            }

            var character = await _database.GetCharacterBagByCode(code);

            if (character == null)
            {
                return NotFound();
            }
            return View(character);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCharacterBag(string code, [Bind("CharacterCode,ItemList,Gold,Silver,Copper")] CharacterBag bag)
        {
            if (code != bag.CharacterCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _database.UpdateCharacterBag(bag);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharacterBagExists(bag.CharacterCode))
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
            return View(bag);
        }

        public async Task<IActionResult> UpdateCharacterEquipped(string code)
        {
            if (code == null)
            {
                return NotFound();
            }

            var character = await _database.GetCharacterEquippedByCode(code);

            if (character == null)
            {
                return NotFound();
            }
            return View(character);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCharacterEquipped(string code, [Bind("CharacterCode,SpecialItems,ArmourClass,ArmourName,MainHand,OffHand")] CharacterEquipped equipped)
        {
            if (code != equipped.CharacterCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _database.UpdateCharacterEquipped(equipped);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharacterEquippedExists(equipped.CharacterCode))
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
            return View(equipped);
        }

        // GET: Character/DeleteCharacter/5
        public async Task<IActionResult> DeleteCharacter(string code)
        {
            if (code == null)
            {
                return NotFound();
            }

            var character = await _database.GetCharacterByCode(code);

            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // POST: Character/DeleteCharacter/
        [HttpPost, ActionName("DeleteCharacter")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCharacterConfirmed(string code)
        {
            await _database.DeleteCharacter(code);
            //await _database.DeleteCharacterBag(code);
            //await _database.DeleteCharacterEquipped(code);

            return RedirectToAction(nameof(Index));
        }

        private bool CharacterExists(string code)
        {
            try
            {
                if (_database.GetCharacterByCode(code) != null)
                {
                    return true;
                }

            }
            catch
            {
                throw;
            }

            return false;
        }

        private bool CharacterBagExists(string code)
        {
            try
            {
                if (_database.GetCharacterBagByCode(code) != null)
                {
                    return true;
                }

            }
            catch
            {
                throw;
            }

            return false;
        }
        private bool CharacterEquippedExists(string code)
        {
            try
            {
                if (_database.GetCharacterEquippedByCode(code) != null)
                {
                    return true;
                }

            }
            catch
            {
                throw;
            }

            return false;
        }
    }
}
