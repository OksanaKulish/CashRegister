using AutoMapper;
using CashRegister.BLL.DTO;
using CashRegister.WEB.ModelsView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.WEB.Mapping
{
    public class MappingWEBProfile : Profile
    {
        public MappingWEBProfile()
        {
            CreateMap<ProductDTO, ProductVM>().ReverseMap();

            CreateMap<OrderDTO, OrderVM>().ReverseMap();
        }
    }
}
