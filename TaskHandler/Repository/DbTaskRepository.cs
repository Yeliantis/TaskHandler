using MetersReader.Data;
using MetersReader.Models;
using MetersReader.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace MetersReader.Repository
{
    public class DbTaskRepository : IDbTaskRepository
    {
        private readonly DataContext _context;
        public DbTaskRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<UserTask> CompleteTaskAsync(int taskId)
        {
                 var task = await _context.Tasks.Where(x=>x.Id== taskId).FirstOrDefaultAsync();
            if (task != null && task.isDone==false) 
            {
                task.isDone = true;
                _context.Update(task);
                await _context.SaveChangesAsync();
            }
            return task;
        }

        public async Task<UserTask> CreateTaskAsync(UserTask userTask)
        {
            var task = new UserTask
            {
                Name = userTask.Name,
                Description = userTask.Description,
                isDone = false,
                DateCreated = DateTime.Now.ToUniversalTime()
            };
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<UserTask> DeleteTaskAsync(int taskId)
        {
            var task = _context.Tasks.Where(x=>x.Id== taskId).FirstOrDefault();
            if (task != null)
            {
                _context.Remove(task);
                await _context.SaveChangesAsync();
            }
            return task;
        }

        public async Task<IEnumerable<UserTask>> GetAllTasksAsync() => await _context.Tasks.ToListAsync();

        public async Task<UserTask> GetTaskByIdAsync(int id)
        {
            var task = await _context.Tasks.Where(x=>x.Id==id).FirstOrDefaultAsync();
            if (task!=null)
            {
                return task;
            }
            return null;
        }

        public async Task<UserTask> UpdateTaskAsync(UserTask userTask)
        {
            if (userTask !=null)
            {
                _context.Tasks.Update(userTask);
                await _context.SaveChangesAsync();
                return userTask;
            }
            return null;
        }
    }
}
