using Dungeons.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dungeons.Data
{
    public interface IUserDataAccess
    {
        Task<User> GetUserByID(int id);
        Task<List<User>> GetUserListAsync();
        Task<bool> CreateUser(User user);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(int id);
    }
}