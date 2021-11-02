using SalesSystem.DTOs;
using SalesSystem.DTOs.Response;
using SalesSystem.Models;
using System.Threading.Tasks;

namespace SalesSystem.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<UserResponse> AuthenticationUser(UserDTO userDTO);
    }
}
