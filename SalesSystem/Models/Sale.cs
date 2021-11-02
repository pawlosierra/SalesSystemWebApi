using System;
using System.Collections.Generic;

#nullable disable

namespace SalesSystem.Models
{
    public partial class Sale
    {
        public Sale()
        {
            Concepts = new HashSet<Concept>();
        }

        public long Id { get; set; }
        public DateTime Date { get; set; }
        public int? ClientId { get; set; }
        public decimal? Total { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<Concept> Concepts { get; set; }
    }
}
