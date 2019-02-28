using CashRegister.BLL.Interfaces;
using CashRegister.BLL.Services;
using CashRegister.DAL.Interfaces;
using CashRegister.DAL.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        /*private readonly string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }*/
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument("DefaultConnection");
            Bind(typeof(IOrderService)).To(typeof(OrderService)).InSingletonScope();
        }
    }
}
