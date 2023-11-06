using MetersReader.Models;

namespace MetersReader.Repository.Contracts
{
    public interface IDbTaskRepository
    {
        /// <summary>
        /// Получает список всех задач из БД
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<UserTask>> GetAllTasksAsync();
        /// <summary>
        /// Получает задачу с определнным id из БД
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        Task<UserTask> GetTaskByIdAsync(int id);
        Task<UserTask> UpdateTaskAsync(UserTask userTask);
        Task<UserTask> CreateTaskAsync(UserTask userTask);
        Task<UserTask> DeleteTaskAsync(int taskId);
        Task<UserTask> CompleteTaskAsync(int taskId);
    }
}
