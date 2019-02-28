using CashRegister.BLL.Infrastructure;
using CashRegister.WEB.Controller;
using CashRegister.WEB.Interface;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.WEB
{
    public class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel(new ServiceModule());
            ICashController cashService = kernel.Get<CashController>();

            var res = cashService.GetProductsByCategory("Promotion");
            foreach (var product in res)
            {
                Console.WriteLine(product.Name);
            }
            Console.WriteLine("Request");
            var res1 = cashService.GetProductsByPrice(80);
            foreach (var product in res1)
            {
                Console.WriteLine(product.Name);
            }
        }
    }
}
