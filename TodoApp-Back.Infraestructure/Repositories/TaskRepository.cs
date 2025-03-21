using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp_Back.Domain.Entities;
using TodoApp_Back.Domain.Repositories;
using TodoApp_Back.Infraestructure.DBContext;

namespace TodoApp_Back.Infraestructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly SQLServerContext _db;
        public TaskRepository(SQLServerContext db)
        {
            _db = db;
        }

        public async Task<TaskEntity> CreateAsync(TaskEntity taskEntity)
        {
            try
            {
                if (taskEntity == null)
                {
                    throw new ArgumentNullException("TaskEntity is null");
                }
                await _db.Tasks.AddAsync(taskEntity);
                await _db.SaveChangesAsync();
                return taskEntity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TaskEntity> DeleteAsync(Guid id)
        {
            TaskEntity? taskEntity = await _db.Tasks.FindAsync(id);
            if (taskEntity == null)
            {
                throw new ArgumentNullException("TaskEntity not exist");
            }
            _db.Tasks.Remove(taskEntity);
            await _db.SaveChangesAsync();
            return taskEntity;
        }

        public async Task<List<TaskEntity>> GetAllAsync()
        {
            List<TaskEntity> tasks = await _db.Tasks.ToListAsync();
            return tasks;
        }

        public async Task<TaskEntity> GetByIdAsync(Guid id)
        {
            TaskEntity? taskEntity = await _db.Tasks.FindAsync(id);
            if (taskEntity == null)
            {
                throw new ArgumentNullException("TaskEntity not exist");
            }
            return taskEntity;

        }

        public async Task<TaskEntity> UpdateAsync(TaskEntity task)
        {
            _db.Tasks.Update(task);
            await _db.SaveChangesAsync();
            return task;
        }
    }
}
