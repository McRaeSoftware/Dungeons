using Dungeons.Data;
using Dungeons.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dungeons.Controllers
{
    public class CharacterController : Controller
    {
        private readonly DungeonsDBContext _database;

        public CharacterController(DungeonsDBContext database)
        {
            _database = database;
        }

        public IActionResult ManageCharacter()
        {
            IEnumerable<Character> characterList = _database.Character;
            return View(characterList);
        }

        public IActionResult CreateCharacter()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCharacter(Character character)
        {
            if (ModelState.IsValid)
            {
                _database.Character.Add(character);
                _database.SaveChanges();
            }
            return View();
        }
    }
}
