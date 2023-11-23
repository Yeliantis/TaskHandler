using MetersReader.Data;
using MetersReader.Models;
using Microsoft.EntityFrameworkCore;
using TaskHandler.Models;
using TaskHandler.Repository.Contracts;

namespace TaskHandler.Repository
{
    public class DbUserRepository : IDbUserRepository
    {
        private readonly DataContext _context;
        public DbUserRepository(DataContext context)
        {
            _context = context;       
        }
        public async Task<IEnumerable<AppUser>> GetAllUsersAsync()
        {
            return await  _context.AppUsers.ToListAsync();
        }
    }
}
