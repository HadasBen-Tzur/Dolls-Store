using Ent;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class OrdersDL : IOrdersDL
    {
        AmericanDolllContext _americanDolllContext;
        public OrdersDL(AmericanDolllContext americanDolllContext)
        {
            _americanDolllContext = americanDolllContext;
        }

        public async Task<List<Orders>> GetOrder(short id)
        {
            return await _americanDolllContext.Orders.Where(x => x.UserId.Equals(id)).ToListAsync();
        }

        public async Task<Orders> AddOrder(Orders order)
        {
            await _americanDolllContext.Orders.AddAsync(order);
            await _americanDolllContext.SaveChangesAsync();
            return order;
        }
    }
}
