using Taskify.Application.DTOs;
using Taskify.Domain;

namespace Taskify.Application.Interfaces
{
    public interface ITaskService
    {
        public Task<List<TaskItem>> GetTasksAsync();

        public Task<TaskItem?> GetTaskByIdAsync(Guid id);

        public Task<TaskItem> CreateTaskAsync(TaskDto dto);

        public Task<bool> DeleteTaskAsync(Guid id);

    }
}
