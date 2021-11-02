using SalesSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesSystem.Repositories.Implements
{
    public class SaleRepository : GenericRepository<Sale>, ISaleRepository
    {
        private readonly LESAContext lESAContext;

        public SaleRepository(LESAContext lESAContext) : base(lESAContext)
        {
            this.lESAContext = lESAContext;
        }

        public async Task<Sale> GetByIdSales(long id)
        {
            var sale = lESAContext.Sales.Where(s => s.Id == id).FirstOrDefault();
            return (Sale)sale;
        }
    }
}
