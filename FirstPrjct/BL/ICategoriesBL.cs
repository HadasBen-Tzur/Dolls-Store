using Ent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface ICategoriesBL
    {
        Task<List<Categories>> GetCategories();
    }
}