using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SalesSystem.DTOs;
using SalesSystem.DTOs.Common;
using SalesSystem.Models;
using SalesSystem.Services;
using System;
using System.Threading.Tasks;

namespace SalesSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ISaleService saleService;


        public SalesController(IMapper mapper, ISaleService saleService)
        {
            this.mapper = mapper;
            this.saleService = saleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sales = await saleService.GetAll();
            return Ok(sales);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var sale = await saleService.GetByIdSales(id);
            return Ok(sale);
        }

        [HttpPost]
        public async Task<IActionResult> Post(SaleDTO saleDTO )
        {
            //var sale = mapper.Map<Sale>(saleDTO);
            //sale.Date = DateTime.Now;
            //lESAContext.Sales.Add(sale);
            //lESAContext.SaveChanges();
            var sale = mapper.Map<Sale>(saleDTO);
            sale.Date = DateTime.Now;
            sale = await saleService.Insert(sale);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public  async Task<IActionResult> Delete(int Id)
        {
            //var sale = lESAContext.Sales.Find(Id);
            //lESAContext.Sales.Remove(sale);
            //lESAContext.SaveChanges();
            var sale = saleService.Delete(Id);
            
            return Ok(sale);
        }
    }
}
