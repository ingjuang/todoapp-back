using TodoApp_Back.Application.Services.Interfaces;
using TodoApp_Back.Domain.Entities;
using TodoApp_Back.Domain.Repositories;
using TodoApp_Back.Util.Responses;

namespace TodoApp_Back.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<PetitionResponse> CreateAsync(TaskEntity task)
        {
            try
            {
                TaskEntity taskEntity = await _taskRepository.CreateAsync(task);
                return new PetitionResponse { Success = true, Message = "Task created successfully", Result = task };
            }
            catch (Exception ex)
            {
                return new PetitionResponse { Success = false, Message = ex.Message };
            }
        }

        public async Task<PetitionResponse> DeleteAsync(Guid id)
        {
            try
            {
                await _taskRepository.DeleteAsync(id);
                return new PetitionResponse { Success = true, Message = "Task deleted successfully" };
            }
            catch (Exception ex)
            {
                return new PetitionResponse { Success = false, Message = ex.Message };
            }
        }
        public async Task<PetitionResponse> GetAllAsync()
        {
            try
            {
                List<TaskEntity> tasks = await _taskRepository.GetAllAsync();
                return new PetitionResponse { Success = true, Message = "Tasks found", Result = tasks };
            }
            catch (Exception ex)
            {
                return new PetitionResponse { Success = false, Message = ex.Message };
            }
        }
        public Task<PetitionResponse> GetByIdAsync(Guid id)
        {
            try
            {
                TaskEntity task = _taskRepository.GetByIdAsync(id).Result;
                return Task.FromResult(new PetitionResponse { Success = true, Message = "Task found", Result = task });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new PetitionResponse { Success = false, Message = ex.Message });
            }
        }
        public Task<PetitionResponse> UpdateAsync(TaskEntity task)
        {
            try
            {
                TaskEntity taskEntity = _taskRepository.UpdateAsync(task).Result;
                return Task.FromResult(new PetitionResponse { Success = true, Message = "Task updated successfully", Result = taskEntity });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new PetitionResponse { Success = false, Message = ex.Message });
            }
        }
    }
}
