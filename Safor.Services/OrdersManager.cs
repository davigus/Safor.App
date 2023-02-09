using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Safor.Services.Models;

namespace Safor.Services
{
    public interface IOrdersManager
    {
        Order GetOrderById(int id);
        OrderDetails GetOrderDetailsByProductId (int productId);
        void CreateNewOrder (string orderDetails);
    }
    
    public class OrdersManager : IOrdersManager
    {
        public Order GetOrderById(int id) => throw new NotImplementedException();
        public OrderDetails GetOrderDetailsByProductId(int productId) => throw new NotImplementedException();
        public void CreateNewOrder(string orderDetails) => throw new NotImplementedException();

    }
}