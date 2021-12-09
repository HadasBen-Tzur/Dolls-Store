using AutoMapper;
using BL;
using DTO;
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
    public class ProductsController : ControllerBase
    {
        private readonly IProductsBL _ProductsBL;
        IMapper _Mapper;
        public ProductsController(IProductsBL ProductsBL, IMapper Mapper)
        {
            _ProductsBL = ProductsBL;
            _Mapper = Mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<ProductsDTO>>> GetallProductsAsync()
        {
            List<Products> products = await _ProductsBL.GetAllProducts();
            List<ProductsDTO> dtos = _Mapper.Map<List<Products>, List<ProductsDTO>>(products);
            return Ok(dtos);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Products>>> GetProductsByCategory(short id)
        {
            List<Products> products = await _ProductsBL.GetProductsByCategory(id);
            List<ProductsDTO> dtos = _Mapper.Map<List<Products>, List<ProductsDTO>>(products);
            return Ok(dtos);
        }

        // POST api/<ProductsController1>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductsController1>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController1>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
