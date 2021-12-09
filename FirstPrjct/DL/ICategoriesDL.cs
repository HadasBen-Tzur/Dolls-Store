using Ent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface ICategoriesDL
    {
        Task<List<Categories>> GetCategories();
    }
}