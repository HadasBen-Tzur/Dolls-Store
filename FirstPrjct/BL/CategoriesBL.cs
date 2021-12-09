using DL;
using Ent;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CategoriesBL : ICategoriesBL
    {
        ICategoriesDL _CategoriesDL;
        public CategoriesBL(ICategoriesDL CategoriesDL)
        {
            _CategoriesDL = CategoriesDL;
        }
        public async Task<List<Categories>> GetCategories()
        {
            return await _CategoriesDL.GetCategories();
        }
    }
}
