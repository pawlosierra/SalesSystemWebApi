using System;
using System.Collections.Generic;

#nullable disable

namespace SalesSystem.Models
{
    public partial class Product
    {
        public Product()
        {
            Concepts = new HashSet<Concept>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Unitprice { get; set; }
        public decimal Cost { get; set; }

        public virtual ICollection<Concept> Concepts { get; set; }
    }
}
