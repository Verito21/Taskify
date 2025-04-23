using Microsoft.EntityFrameworkCore;
using Taskify.Application.DTOs;
using Taskify.Application.Interfaces;
using Taskify.Domain;
using Taskify.Infrastructure.Data;

namespace Taskify.Services
{
    // Services/TaskService.cs
    public class TaskService : ITaskService
    {
        private readonly TaskRepository _repo;

        public TaskService(TaskRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<TaskItem>> GetTasksAsync() => await _repo.GetAllAsync();
        public async Task<TaskItem?> GetTaskByIdAsync(Guid id) => await _repo.GetByIdAsync(id);
        public async Task<TaskItem> CreateTaskAsync(TaskDto dto) =>
            await _repo.AddAsync(new TaskItem { Title = dto.Title, Description = dto.Description });

        public async Task<bool> DeleteTaskAsync(Guid id) => await _repo.DeleteAsync(id);
    }

}
