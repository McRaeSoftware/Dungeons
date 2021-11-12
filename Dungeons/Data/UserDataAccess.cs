using Dungeons.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dungeons.Data
{
    public class UserDataAccess : IUserDataAccess
    {
        public DungeonsDBContext _database;

        public async Task<List<User>> GetUserListAsync()
        {
            return await _database.User.ToListAsync();
        }

        public async Task<User> GetUserByID(int id)
        {
            return await _database.User.FirstOrDefaultAsync(user => user.User_ID == id);
        }

        public async Task<bool> CreateUser(User user)
        {
            try
            {
                _database.Add(user);
                if (await _database.SaveChangesAsync() > 0)
                {
                    return true; // 1 or more rows were affected
                }
            }
            catch
            {
                throw;
            }

            return false;
        }

        public async Task<bool> UpdateUser(User user)
        {
            try
            {
                _database.Update(user);
                if (await _database.SaveChangesAsync() > 0)
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

        public async Task<bool> DeleteUserByID(int id)
        {
            try
            {
                var user = await _database.User.FindAsync(id);

                _database.User.Remove(user);
                if(await _database.SaveChangesAsync() > 0)
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
