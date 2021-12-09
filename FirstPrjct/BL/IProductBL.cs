using Ent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IProductsBL
    {
        Task<List<Products>> GetAllProducts();
        Task<List<Products>> GetProductsByCategory(short id);
    }
}