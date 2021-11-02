using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesSystem.DTOs;
using SalesSystem.Models;
using AutoMapper;

namespace SalesSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly LESAContext lESAContext;

        public ProductsController(LESAContext lESAContext, IMapper mapper)
        {
            this.lESAContext = lESAContext;
            this.mapper = mapper;
        }

        [HttpGet]

        public IActionResult Get()
        {
            var lst = lESAContext.Products.ToList();
            return Ok(lst);
        }

        [HttpPost]

        public IActionResult Post(ProductDTO productDTO )
        {
            //Product product = new Product();
            //product.Name = productDTO.Name;
            //product.Unitprice = productDTO.Unitprice;
            //product.Cost = productDTO.Cost;
            var product = mapper.Map<Product>(productDTO);
            lESAContext.Products.Add(product);
            lESAContext.SaveChanges();
            return Ok();
        }
    }
}
