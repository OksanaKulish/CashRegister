using CashRegister.BLL.DTO;
using CashRegister.WEB.ModelsView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.WEB.Interface
{
    public interface ICashController
    {
        IEnumerable<ProductVM> GetProductsByCategory(string category);

        IEnumerable<ProductVM> GetProductsByPrice(decimal price);

        void MakeOrder(int? id);

        void Dispose();
    }
}
