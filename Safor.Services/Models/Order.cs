using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safor.Services.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderCode { get; set; }
        public string OrderName { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public Customer Customer { get; set; }
    }
}
