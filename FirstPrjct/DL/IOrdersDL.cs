using Ent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IOrdersDL
    {
        Task<List<Orders>> GetOrder(short id);
        Task<Orders> AddOrder(Orders order);
    }
}