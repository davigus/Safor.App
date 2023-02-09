using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safor.Services.Models
{
    public class OrderDetails
    {
        public int Id {get; set;}
        public Order Order{get; set;}
        public Product Product {get;set;}
        public decimal Quantity {get; set;}
    }
}
