﻿using SalesSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesSystem.Services
{
    public interface ISaleService : IGenericService<Sale>
    {
        Task<Sale> GetByIdSales(long id);
    }
}