using BL;
using Ent;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstPrjct.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IOrdersBL _ordersBL;
        public OrdersController(IOrdersBL OrdersBL)
        {
            _ordersBL = OrdersBL;
        }
        [HttpGet("{id}")]
        public async Task<List<Orders>> GetOrder(short id)
        {
            //if (user == null)
            //    return NoContent();
            return await _ordersBL.GetOrder(id);
        }
        // POST api/<OrdersController>
        [HttpPost]
        public async Task<Orders> AddOrder([FromBody] Orders order)
        {
            return await _ordersBL.AddOrder(order);
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
