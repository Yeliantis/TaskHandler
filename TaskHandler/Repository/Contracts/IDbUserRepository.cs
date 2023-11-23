using MetersReader.Models;
using TaskHandler.Models;

namespace TaskHandler.Repository.Contracts
{
    public interface IDbUserRepository
    {
        Task<IEnumerable<AppUser>> GetAllUsersAsync();
    }
}
