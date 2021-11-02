using SalesSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesSystem.Repositories.Implements
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly LESAContext lESAContext;

        public ProductRepository(LESAContext lESAContext) : base(lESAContext)
        {
            this.lESAContext = lESAContext;
        }
    }
}
