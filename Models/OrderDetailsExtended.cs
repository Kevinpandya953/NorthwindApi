using Humanizer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models;

public partial class OrderDetailsExtended
{
    public int OrderID { get; set; }

    public int ProductID { get; set; }

    public string ProductName { get; set; }

    public decimal UnitPrice { get; set; }

    public short Quantity { get; set; }

    public float Discount { get; set; }

    public decimal? ExtendedPrice { get; set; }
    
    public decimal TotalPrice => UnitPrice * Quantity * (decimal)(1 - Discount);

}