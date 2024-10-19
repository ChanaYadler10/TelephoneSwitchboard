using AutoMapper;
using Repository.Interfaces;
using Service.DTOs;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskEntity = Repository.Models.Task;

namespace Service.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public List<TaskDto> GetAllTasks()
        {
            var tasks = _taskRepository.GetAllTasks();
            return _mapper.Map<List<TaskDto>>(tasks);
        }

        public TaskDto GetTaskById(int id)
        {
            var task = _taskRepository.GetTaskById(id);
            return _mapper.Map<TaskDto>(task);
        }

        public TaskDto AddTask(TaskCreateDto taskCreateDto)
        {
            var task = _mapper.Map<TaskEntity>(taskCreateDto);
            var addedTask = _taskRepository.AddTask(task);
            return _mapper.Map<TaskDto>(addedTask);
        }
        public TaskDto DeleteTask(int id)
        {
            var task = _taskRepository.DeleteTask(id);
            return _mapper.Map<TaskDto>(task);
        }


        public async Task<TaskDto> UpdateTaskAsync(TaskDto taskDto)
        {
            var taskEntity = _mapper.Map<TaskEntity>(taskDto);
            var updatedTask = await Task.Run(() => _taskRepository.UpdateTaskAsync(taskEntity));
            return _mapper.Map<TaskDto>(updatedTask);
        }
    }
}
