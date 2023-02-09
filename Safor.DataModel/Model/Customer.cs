using System;
using System.Collections.Generic;

namespace Safor.DataModel.Model;

public partial class Customer
{
    public int Id { get; set; }

    public string CustomerName { get; set; } = null!;

    public string CustomerVatnumber { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
