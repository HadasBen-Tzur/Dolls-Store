using Ent;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class UserDL : IUserDL
    {
        //string filepath = @"C:\Users\user\Documents\מסלול\נוסבכר -WEB API\מעבדות\1\HomeWork1.2\users.txt";

        AmericanDolllContext _AmericanDolllContext;
        public UserDL(AmericanDolllContext AmericanDolllContext)
        {
            _AmericanDolllContext = AmericanDolllContext;
        }
        public async Task<Users> UpdateUser(short id, Users user)
        {
            try
            {
                var userToUpdate = await _AmericanDolllContext.Users.FindAsync(id);
                user.UserId = userToUpdate.UserId;
                if (userToUpdate == null)
                {
                    return null;
                }
                _AmericanDolllContext.Entry(userToUpdate).CurrentValues.SetValues(user);
                await _AmericanDolllContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                var d = 0;
            }

            return user;
        }
        public async Task<Users> AddUser(Users user)
        {
            await _AmericanDolllContext.Users.AddAsync(user);
            await _AmericanDolllContext.SaveChangesAsync();
            return user;
        }
        public async Task<Users> GetUser(string email, string password)
        {

            return await _AmericanDolllContext.Users.Where(User => User.Password == password
                                                            && User.EMail == email).FirstOrDefaultAsync();

        }
    }
}
