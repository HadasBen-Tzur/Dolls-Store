using Ent;
using System.Threading.Tasks;

namespace DL
{
    public interface IUserDL
    {
        Task<Users> AddUser(Users user);
        Task<Users> GetUser(string email, string password);
        Task<Users> UpdateUser(short id, Users user);
    }
}