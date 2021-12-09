using AutoMapper;
using DTO;
using Ent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstPrjct
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Products, ProductsDTO>();
        }
    }
}
