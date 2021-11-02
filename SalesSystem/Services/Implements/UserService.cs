using SalesSystem.DTOs;
using SalesSystem.DTOs.Response;
using SalesSystem.Models;
using SalesSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesSystem.Services.Implements
{
    public class UserService : GenericService<User>, IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository) : base(userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<UserResponse> AuthenticationUser(UserDTO userDTO)
        {
            return await userRepository.AuthenticationUser(userDTO);
        }
    }
}
