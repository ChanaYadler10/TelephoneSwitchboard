using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Interfaces;
using Repository.Models;
using System.Collections.Generic;
using System.Linq;
using TaskEntity = Repository.Models.Task; 
namespace Repository.Implementations
{
    public class TaskRepository : ITaskRepository
    {
        private readonly OmnicrmContext _context;

        public TaskRepository(OmnicrmContext context)
        {
            _context = context;
        }

        public IEnumerable<TaskEntity> GetAllTasks()
        {
            return _context.Tasks.Include(s=>s.StatusTaskTbl).ToList();
        }

        public TaskEntity GetTaskById(int taskId)
        {
            return _context.Tasks.FirstOrDefault(t => t.TaskId == taskId);
        }

        public TaskEntity AddTask(TaskEntity task)
        {
            task.Guid = Guid.NewGuid();
            task.DateCreated = DateTime.UtcNow;
            task.DateModified = DateTime.UtcNow;

            // Ensure the status task is correctly linked
            task.StatusTaskTbl = _context.Set<StatusTask>().Find(task.StatusTaskTblId);

            _context.Set<TaskEntity>().Add(task);
            _context.SaveChanges();
            return task;
        }

        public TaskEntity UpdateTaskAsync(TaskEntity task)
        {
            var existingTask = _context.Set<TaskEntity>().Find(task.TaskId);
            if (existingTask == null)
            {
                throw new Exception("Task not found");
            }

            existingTask.Description = task.Description;
            existingTask.DueDate = task.DueDate;
            existingTask.StatusTaskTblId = task.StatusTaskTblId;
            existingTask.StatusTaskTbl = _context.Set<StatusTask>().Find(task.StatusTaskTblId);
            existingTask.DateModified = DateTime.UtcNow;

            _context.Set<TaskEntity>().Update(existingTask);
            _context.SaveChanges();

            return existingTask;
        }


        public TaskEntity DeleteTask(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
                return task;
            }
            return null;
        }
    }
}
