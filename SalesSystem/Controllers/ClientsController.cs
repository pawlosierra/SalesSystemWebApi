using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SalesSystem.DTOs;
using SalesSystem.Models;
using SalesSystem.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using SalesSystem.DTOs.Common;

namespace SalesSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ClientsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IClientService clientService;

        public ClientsController(IMapper mapper, IClientService clientService)
        {
            this.mapper = mapper;
            this.clientService = clientService;
        }
        /// <summary>
        /// Get all Clients of Sale System.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clients = await clientService.GetAll();
            return Ok(clients);
        }

        /// <summary>
        /// Get specific clint using the ID. 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var client = await clientService.GetById(Id);
            return Ok(client);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ClientDTO clientDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var client = mapper.Map<Client>(clientDTO);
                client = await clientService.Insert(client);
                return Ok(client);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
          
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(ClientDTO clientDTO, int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var flag = await clientService.GetById(Id);
                if (flag == null)
                {
                    return NotFound();
                }
                var client = mapper.Map<Client>(clientDTO);
                client.Id = Id;
                flag.Name = client.Name;
                client.Name = flag.Name;
                await clientService.UpDate(client);
                return Ok(client);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
            
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            await clientService.Delete(Id);
            return Ok(Id);
        }
    }
}


//private readonly IMapper mapper;
//private readonly LESAContext lESAContext;
//public ClientsController(LESAContext lESAContext, IMapper mapper)
//{
//    this.lESAContext = lESAContext;
//    this.mapper = mapper;
//}
//[HttpGet]
//public IActionResult Get()
//{
//    var lst = lESAContext.Clients.ToList();
//    return Ok(lst);
//}

//[HttpGet("{Id}")]
//public IActionResult GetById(int id)
//{
//    var client = lESAContext.Clients.Find(id);
//    return Ok(client);
//}

//[HttpPost]

//public IActionResult Post(ClientDTO clientDTO)
//{
//    var client = mapper.Map<Client>(clientDTO);
//    lESAContext.Clients.Add(client);
//    lESAContext.SaveChanges();
//    return Ok(client);
//}

//[HttpDelete("{Id}")]
//public IActionResult Delete(int Id)
//{
//    var client = lESAContext.Clients.Find(Id);
//    lESAContext.Clients.Remove(client);
//    lESAContext.SaveChanges();
//    return Ok();
//}