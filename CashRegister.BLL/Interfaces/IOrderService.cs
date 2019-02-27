using CashRegister.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.BLL.Interfaces
{
    public interface IOrderService
    {
        void MakeOrder(OrderDTO orderDto);
        ProductDTO GetProduct(int? id);
        IEnumerable<ProductDTO> GetProducts();
        void Dispose();
    }
}
