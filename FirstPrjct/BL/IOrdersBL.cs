using Ent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IOrdersBL
    {
        Task<List<Orders>> GetOrder(short id);
        Task<Orders> AddOrder(Orders order);
    }
}