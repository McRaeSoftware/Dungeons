using Dungeons.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dungeons.Data
{
    public interface IUserDataAccess
    {
        Task<List<User>> GetUserListAsync();
        Task<User> GetUserByID(int id);
        Task<bool> CreateUser(User user);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(int id);
    }
}