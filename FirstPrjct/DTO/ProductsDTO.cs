using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class ProductsDTO
    {
        public short ProductId { get; set; }
        public string ProductName { get; set; }
        public short? CategoryId { get; set; }
        public int? Price { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
    }
}
