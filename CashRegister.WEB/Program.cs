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
            ICashController cashController = kernel.Get<CashController>();
        }
    }
}
