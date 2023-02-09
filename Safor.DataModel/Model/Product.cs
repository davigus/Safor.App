using System;
using System.Collections.Generic;

namespace Safor.DataModel.Model;

public partial class Product
{
    public int Id { get; set; }

    public string? ProductName { get; set; }

    public string? ProductDescription { get; set; }

    public string? ProductionCode { get; set; }

    public string? ProductionRevision { get; set; }

    public string? ProductionCodeRevision { get; set; }

    public string? ProductionFileName { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();
}
