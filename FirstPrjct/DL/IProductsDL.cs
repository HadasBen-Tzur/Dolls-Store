using Ent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IProductsDL
    {
        Task<List<Products>> GetAllProducts();
        Task<List<Products>> GetProductsByCategory(short id);
    }
}