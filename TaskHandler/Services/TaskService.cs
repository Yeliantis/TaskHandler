using MetersReader.Models;
using MetersReader.Repository.Contracts;
using MetersReader.Services.Contracts;

namespace MetersReader.Services
{
    public class TaskService : ITaskService
    {
        private readonly IDbTaskRepository _taskRepository;
        public TaskService(IDbTaskRepository taskRepository)
        {
            _taskRepository= taskRepository;
        }

        public async Task<UserTask> CompleteTaskAsync(int taskId)
        {
            return await _taskRepository.CompleteTaskAsync(taskId);
        }

        public async Task<UserTask> CreateTaskAsync(UserTask task)
        {
            return await _taskRepository.CreateTaskAsync(task);
        }

        public async Task<UserTask> DeleteTaskAsync(int taskId)
        {
            return await _taskRepository.DeleteTaskAsync(taskId);
        }

        public async Task<IEnumerable<UserTask>> GetAllTaskAsync()
        {
            return await _taskRepository.GetAllTasksAsync();
        }

        public async Task<UserTask> GetTaskByIdAsync(int taskId)
        {
            return await _taskRepository.GetTaskByIdAsync(taskId);
        }

        public async Task<UserTask> UpdateTaskAsync(UserTask task)
        {
            return await _taskRepository.UpdateTaskAsync(task);
        }
    }
}
