using DL;
using Ent;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ProductsBL : IProductsBL
    {
        IProductsDL _ProductsDL;
        public ProductsBL(IProductsDL ProductsDL)
        {
            _ProductsDL = ProductsDL;
        }
        public async Task<List<Products>> GetAllProducts()
        {
            return await _ProductsDL.GetAllProducts();
        }

        public async Task<List<Products>> GetProductsByCategory(short id)
        {
            return await _ProductsDL.GetProductsByCategory(id);
        }
    }
}
