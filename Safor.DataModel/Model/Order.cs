using System;
using System.Collections.Generic;

namespace Safor.DataModel.Model;

public partial class Order
{
    public int Id { get; set; }

    public string OrderCode { get; set; } = null!;

    public string OrderName { get; set; } = null!;

    public DateTime? OrderDate { get; set; }

    public DateTime? DueDate { get; set; }

    public int? CustomerId { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();
}
