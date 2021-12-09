using BL;
using Ent;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstPrjct.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        ICategoriesBL _CategoriesBL;
        public CategoriesController(ICategoriesBL CategoriesBL)
        {
            _CategoriesBL = CategoriesBL;
        }

        [HttpGet]
        public async Task<List<Categories>> GetCategoriesAsync()
        {
            List<Categories> categories = await _CategoriesBL.GetCategories();
            return categories;
        }

        //// POST api/<CategoriesController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<CategoriesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}
    }
}
