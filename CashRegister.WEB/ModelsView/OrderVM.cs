using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.WEB.ModelsView
{
    public class OrderVM
    {
        public int Id { get; set; }
        public decimal Sum { get; set; }
        public DateTime Data { get; set; }
        public int Quantity { get; set; }
    }
}
