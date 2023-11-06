using MetersReader.Models;

namespace MetersReader.Services.Contracts
{
    public interface ITaskService
    {
        Task<IEnumerable<UserTask>> GetAllTaskAsync();
        Task<UserTask> CreateTaskAsync(UserTask task);
        Task<UserTask> GetTaskByIdAsync(int taskId);
        Task<UserTask> UpdateTaskAsync(UserTask task);
        Task<UserTask> DeleteTaskAsync(int taskId);
        Task<UserTask> CompleteTaskAsync(int taskId);
    }
}
