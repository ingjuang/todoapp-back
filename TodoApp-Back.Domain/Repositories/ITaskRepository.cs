using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp_Back.Domain.Entities;

namespace TodoApp_Back.Domain.Repositories
{
    public interface ITaskRepository
    {
        Task<List<TaskEntity>> GetAllAsync();
        Task<TaskEntity> GetByIdAsync(Guid id);
        Task<TaskEntity> CreateAsync(TaskEntity task);
        Task<TaskEntity> UpdateAsync(TaskEntity task);
        Task<TaskEntity> DeleteAsync(Guid id);
    }
}
