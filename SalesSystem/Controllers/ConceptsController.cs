using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesSystem.Models;

namespace SalesSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConceptsController : ControllerBase
    {
        private readonly LESAContext lESAContext;

        public ConceptsController(LESAContext lESAContext)
        {
            this.lESAContext = lESAContext;
        }

        [HttpGet]

        public IActionResult Get()
        {
            var lst = lESAContext.Concepts.ToList();
            return Ok(lst);
        }

        [HttpGet("{Id}")]
        public IActionResult GetIdAll(int Id)
        {
            var lst = lESAContext.Concepts.Find(Id);
            return Ok(lst);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(long Id)
        {
            var lst = lESAContext.Concepts.Find(Id);
            lESAContext.Remove(lst);
            lESAContext.SaveChanges();
            return Ok(lst);
        }

      
    }
}
