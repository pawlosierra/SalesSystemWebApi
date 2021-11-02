using SalesSystem.Models;
using SalesSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesSystem.Services.Implements
{
    public class ProductService : GenericService<Product>, IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository) : base(productRepository)
        {
            this.productRepository = productRepository;
        }
    }
}
