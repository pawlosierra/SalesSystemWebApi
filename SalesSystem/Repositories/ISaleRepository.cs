using SalesSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesSystem.Repositories
{
    public interface ISaleRepository : IGenericRepository<Sale>
    {
        Task<Sale> GetByIdSales(long id);
    }
}
