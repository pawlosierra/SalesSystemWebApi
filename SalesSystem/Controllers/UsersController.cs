using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SalesSystem.DTOs;
using SalesSystem.Models;
using SalesSystem.Services;
using System.Linq;
using System.Threading.Tasks;

namespace SalesSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //private readonly LESAContext lESAContext;
        private readonly IMapper mapper;
        private readonly IUserService userService;

        public UsersController(IMapper mapper, IUserService userService)
        {
            this.mapper = mapper;
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //var lst = lESAContext.Users.ToList();
            //return Ok(lst);
            var users = await userService.GetAll();
            return Ok(users);
            
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authentication([FromBody] UserDTO userDTO)
        {
            //var user = mapper.Map<User>(userDTO);

            var user = await userService.AuthenticationUser(userDTO);

            if (user == null)
            {
                return Unauthorized("Incorrect User or Password ");
            }

            return Ok(user);
        }


    }
}
