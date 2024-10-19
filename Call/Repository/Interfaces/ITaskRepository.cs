using System.Collections.Generic;
using TaskEntity = Repository.Models.Task; // Alias to differentiate between tasks

namespace Repository.Interfaces
{
    public interface ITaskRepository
    {
        IEnumerable<TaskEntity> GetAllTasks();
        TaskEntity GetTaskById(int id);
        TaskEntity AddTask(TaskEntity task);
        TaskEntity UpdateTaskAsync(TaskEntity task);
        TaskEntity DeleteTask(int id);
    }
}
