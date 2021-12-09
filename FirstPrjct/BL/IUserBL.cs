using Ent;
using System.Threading.Tasks;

namespace BL
{
    public interface IUserBL
    {
        Task<Users> AddUser(Users user);
        Task<Users> GetUser(string email, string password);
        Task UpdateUser(short id, Users user);
    }
}