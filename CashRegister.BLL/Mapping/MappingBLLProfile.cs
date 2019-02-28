using AutoMapper;
using CashRegister.BLL.DTO;
using CashRegister.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.BLL.Mapping
{
    public class MappingBLLProfile : Profile
    {
        public MappingBLLProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();

            CreateMap<Order, OrderDTO>().ReverseMap();
        }
    }
}
