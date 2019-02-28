using AutoMapper;
using CashRegister.BLL.DTO;
using CashRegister.BLL.Interfaces;
using CashRegister.WEB.Interface;
using CashRegister.WEB.ModelsView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.WEB.Controller
{
    public class CashController : ICashController
    {
        private IOrderService OrderService { get; set; }

        public CashController(IOrderService orderService)
        {
            this.OrderService = orderService;
        }


        public IEnumerable<ProductVM> GetProductsByCategory(string category)
        {
            
            if (string.IsNullOrEmpty(category))
            {
                Console.WriteLine("Name of category isn't unassigned");
            }
            var result = OrderService.GetProductsByCategory(category);
            if (!result.Any())
            {
                Console.WriteLine("Product of this category wasn't found");
            }
            return Mapper.Map<IEnumerable<ProductDTO>, IEnumerable<ProductVM>>(result);
        }

        public IEnumerable<ProductVM> GetProductsByPrice(decimal price)
        {
            
            if (price < 0)
            {
                Console.WriteLine("Price must be positive");
            }
            var result = OrderService.GetProductsByPrice(price);
            if (!result.Any())
            {
                Console.WriteLine("Product with this price wasn't found");
            }
            return Mapper.Map<IEnumerable<ProductDTO>, IEnumerable<ProductVM>>(result);
        }

        public void MakeOrder(int? id)
        {
            try
            {
                ProductDTO product = OrderService.GetProduct(id);
                var order = new OrderVM { Id = product.Id };
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
        public void Dispose()
        {
            OrderService.Dispose();
        }
    }
}
