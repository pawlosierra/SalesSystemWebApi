using System;
using System.Collections.Generic;

#nullable disable

namespace SalesSystemAPI.Models
{
    public partial class Concept
    {
        public long Id { get; set; }
        public long SaleId { get; set; }
        public int Quantity { get; set; }
        public decimal Unitprice { get; set; }
        public decimal Amount { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Sale Sale { get; set; }
    }
}
