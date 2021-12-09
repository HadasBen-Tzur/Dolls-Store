using Ent;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class CategoriesDL : ICategoriesDL
    {
        AmericanDolllContext _americanDolllContext;
        public CategoriesDL(AmericanDolllContext americanDolllContext)
        {
            _americanDolllContext = americanDolllContext;
        }
        public async Task<List<Categories>> GetCategories()
        {
            return await _americanDolllContext.Categories.ToListAsync();
        }
    }
}
