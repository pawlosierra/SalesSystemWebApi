using SalesSystem.Models;
using SalesSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesSystem.Services.Implements
{
    public class SaleService : GenericService<Sale>, ISaleService
    {
        private readonly ISaleRepository saleRepository;

        public SaleService(ISaleRepository saleRepository) : base(saleRepository)
        {
            this.saleRepository = saleRepository;
        }

        public async Task<Sale> GetByIdSales(long id)
        {
            return await saleRepository.GetByIdSales(id);
        }
    }
}
