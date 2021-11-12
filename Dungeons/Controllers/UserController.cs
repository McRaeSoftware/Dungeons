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
    public class UserController : Controller
    {
        public IUserDataAccess _database { get; set; }

        public UserController(IUserDataAccess database)
        {
            _database = database;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            return View(await _database.GetUserListAsync());
        }

        // GET: User/DisplayUser/5
        public async Task<IActionResult> DisplayUser(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _database.GetUserByID((int)id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: User/CreateUser
        public IActionResult CreateUser()
        {
            return View();
        }

        // POST: User/CreateUser
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser([Bind("User_ID,Username,Email,Password")] User user)
        { 
            if (ModelState.IsValid)
            {
                await _database.CreateUser(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: User/EditUser/5
        public async Task<IActionResult> EditUser(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _database.GetUserByID((int)id);

            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: User/EditUser/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(int id, [Bind("User_ID,Username,Email,Password")] User user)
        {
            if (id != user.User_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _database.UpdateUser(user);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.User_ID))
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
            return View(user);
        }

        // GET: User/DeleteUser/5
        public async Task<IActionResult> DeleteUser(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _database.GetUserByID((int)id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: User/DeleteUser/5
        [HttpPost, ActionName("DeleteUser")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUserConfirmed(int id)
        {
            await _database.DeleteUser(id);
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            try
            {
                if (_database.GetUserByID(id) != null)
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
