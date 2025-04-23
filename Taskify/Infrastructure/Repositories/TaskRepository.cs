// Infrastructure/Repositories/TaskRepository.cs
using Microsoft.EntityFrameworkCore;
using Taskify.Domain;
using Taskify.Infrastructure.Data;

public class TaskRepository
{
    private readonly AppDbContext _context;

    public TaskRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<TaskItem>> GetAllAsync() => await _context.Tasks.ToListAsync();

    public async Task<TaskItem?> GetByIdAsync(Guid id) => await _context.Tasks.FindAsync(id);

    public async Task<TaskItem> AddAsync(TaskItem task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null) return false;
        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
        return true;
    }
}
