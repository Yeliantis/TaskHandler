using TaskHandler.Models;

namespace TaskHandler.Services.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<AppUser>> GetAllUsersAsync();
    }
}
