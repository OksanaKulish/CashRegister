using AutoMapper;
using CashRegister.BLL.DTO;
using CashRegister.BLL.Interfaces;
using CashRegister.DAL.Entities;
using CashRegister.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.BLL.Services
{
    public class OrderService : IOrderService
    {
        IUnitOfWork Database { get; set; }

        public OrderService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }

        public IEnumerable<ProductDTO> GetProductsByPrice(decimal price)
        {
            IEnumerable<Product> products = Database.Products.Find(product => product.Price == price);
            return Mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);
        }

        public IEnumerable<ProductDTO> GetProductsByCategory(string category)
        {
            IEnumerable<Product> products = Database.Products.Find(product => product.Category.Name == category);
            return Mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);
        }

        public void MakeOrder(OrderDTO orderDTO)
        {
            Product product = Database.Products.Get(orderDTO.Id);

            if (product == null)
                throw new Exception("Product was not founded");

            Order order = Mapper.Map<OrderDTO, Order>(orderDTO);
            Database.Orders.Create(order);
            Database.Save();
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            return Mapper.Map<IEnumerable<Product>, List<ProductDTO>>(Database.Products.GetAll());
        }

        public ProductDTO GetProduct(int? id)
        {
            if (id == null)
                throw new Exception("Product is null");
            var product = Database.Products.Get(id.Value);
            if (product == null)
                throw new Exception("Product was not founded");

            return Mapper.Map<Product, ProductDTO>(product);
        }

       
        public decimal GetTotal(int id)
        {
            var ShoppingOrderId = Database.Orders.Get(id);
            
            decimal? total = decimal.Zero;
            /*total = (decimal?)(from orderItems in Database.Orders
                               where orderItems.CartId == ShoppingOrderId
                               select (int?)orderItems.Quantity *
                               orderItems.Product.UnitPrice).Sum();*/
            return total ?? decimal.Zero;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
