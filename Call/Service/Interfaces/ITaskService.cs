using Service.DTOs;
using System.Collections.Generic;
using TaskEntity = Repository.Models.Task; // Alias to differentiate between tasks

namespace Service.Interfaces
{
    public interface ITaskService
    {
        List<TaskDto> GetAllTasks();
        TaskDto GetTaskById(int id);
        TaskDto AddTask(TaskCreateDto taskDto);
        TaskDto DeleteTask(int id);
        Task<TaskDto> UpdateTaskAsync(TaskDto taskDto);
    }
}
