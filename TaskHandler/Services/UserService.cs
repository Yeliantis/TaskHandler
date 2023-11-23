using Microsoft.AspNetCore.Authorization;
using TaskHandler.Models;
using TaskHandler.Repository.Contracts;
using TaskHandler.Services.Contracts;

namespace TaskHandler.Services
{
    public class UserService : IUserService
    {
        private readonly IDbUserRepository _userRepository;
        public UserService(IDbUserRepository userRepository)
        {
                _userRepository = userRepository;
        }
       
        public async Task<IEnumerable<AppUser>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }
    }
}
