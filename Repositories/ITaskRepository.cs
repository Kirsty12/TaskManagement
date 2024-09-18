using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskManagementSystem.Models
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskItem>> GetAllTasks();
        Task<TaskItem> GetTaskById(int id);
        Task AddTask(TaskItem task);
        Task UpdateTask(TaskItem task);
        Task DeleteTask(int id);
    }
}