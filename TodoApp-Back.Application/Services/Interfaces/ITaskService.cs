using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp_Back.Domain.Entities;
using TodoApp_Back.Util.Responses;

namespace TodoApp_Back.Application.Services.Interfaces
{
    public interface ITaskService
    {
        public Task<PetitionResponse> GetAllAsync();
        public Task<PetitionResponse> GetByIdAsync(Guid id);
        public Task<PetitionResponse> CreateAsync(TaskEntity task);
        public Task<PetitionResponse> UpdateAsync(TaskEntity task);
        public Task<PetitionResponse> DeleteAsync(Guid id);
    }
}
