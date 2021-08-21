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
        private readonly DungeonsDBContext _database;

        public UserController(DungeonsDBContext context)
        {
            _database = context;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            return View(await _database.User.ToListAsync());
        }

        // GET: User/DisplayUser/5
        public async Task<IActionResult> DisplayUser(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _database.User
                .FirstOrDefaultAsync(m => m.User_ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: User/Create
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
                _database.Add(user);
                await _database.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> EditUser(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _database.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
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
                    _database.Update(user);
                    await _database.SaveChangesAsync();
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

        // GET: User/Delete/5
        public async Task<IActionResult> DeleteUser(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _database.User
                .FirstOrDefaultAsync(m => m.User_ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("DeleteUser")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUserConfirmed(int id)
        {
            var user = await _database.User.FindAsync(id);
            _database.User.Remove(user);
            await _database.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _database.User.Any(e => e.User_ID == id);
        }
    }
}
