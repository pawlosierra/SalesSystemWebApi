using SalesSystem.DTOs;
using SalesSystem.DTOs.Response;
using SalesSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesSystem.Services
{
    public interface IUserService : IGenericService<User>
    {
        Task<UserResponse> AuthenticationUser(UserDTO userDTO);
    }
}
