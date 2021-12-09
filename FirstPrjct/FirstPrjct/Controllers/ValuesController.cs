using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;
using BL;
using Ent;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstPrjct.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase

    {
        IUserBL _userBL;
        ILogger<ValuesController> _logger;
        public ValuesController(IUserBL userBL, ILogger<ValuesController> logger)
        {
            _userBL = userBL;
            _logger = logger;
        }


        [HttpGet("{eMail}/{Password}")]
        public async Task<ActionResult<Users>> loginAsync(string eMail, string Password)
        {
            try
            {
                _logger.LogInformation($"user login: email: {eMail} password: {Password}");
                Users user = await _userBL.GetUser(eMail, Password);
                if (user == null)
                    return NoContent();
                return Ok(user);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message + ex.StackTrace);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }


        // POST api/<ValuesController>
        [HttpPost]
        public async Task AddUser([FromBody] Users user)
        {
            // UserBL userBl = new UserBL();
            await _userBL.AddUser(user);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task UpdateUser(short id, [FromBody] Users userToUpdate)
        {
            // UserBL userBl = new UserBL();
            await _userBL.UpdateUser(id, userToUpdate);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
