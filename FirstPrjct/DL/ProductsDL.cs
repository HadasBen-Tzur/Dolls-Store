using Ent;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class ProductsDL : IProductsDL
    {
        AmericanDolllContext _americanDolllContext;
        public ProductsDL(AmericanDolllContext americanDolllContext)
        {
            _americanDolllContext = americanDolllContext;
        }
        public async Task<List<Products>> GetAllProducts()
        {
            return await _americanDolllContext.Products.ToListAsync();
        }

        public async Task<List<Products>> GetProductsByCategory(short id)
        {
            return await _americanDolllContext.Products.Where(x => x.CategoryId.Equals(id)).ToListAsync();
        }
    }
}
