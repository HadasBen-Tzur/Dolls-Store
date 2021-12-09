using DL;
using Ent;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class UserBL : IUserBL

    {
        IUserDL _userDL;

        public UserBL(IUserDL userDL)
        {
            _userDL = userDL;
        }
        public async Task<Users> GetUser(string email, string password)
        {
            return await _userDL.GetUser(email, password);
        }

        public async Task<Users> AddUser(Users user)
        {
            return await _userDL.AddUser(user);
        }

        public async Task UpdateUser(short id, Users user)
        {
            await _userDL.UpdateUser(id, user);
        }

    }

}
