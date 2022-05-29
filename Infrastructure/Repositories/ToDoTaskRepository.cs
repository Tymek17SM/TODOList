using Domain.Entitis;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.ExtensionMethods;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ToDoTaskRepository : IToDoTaskRepository
    {
        private readonly ToDoListContext _context;
        public ToDoTaskRepository(ToDoListContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ToDoTask>> GetAllAsynch(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy)
        {
            return await _context.Tasks
                .Where(t => t.Title.ToLower().Contains(filterBy.ToLower()) || t.Description.ToLower().Contains(filterBy.ToLower()))
                .OrderByPropertyName(sortField, ascending)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> GetAllCountAsynch(string filterBy)
        {
            return await _context.Tasks
                .Where(t => t.Title.ToLower().Contains(filterBy.ToLower()) || t.Description.ToLower().Contains(filterBy.ToLower()))
                .CountAsync();
        }

        public async Task<ToDoTask> GetByIdAsynch(int id)
        {
            return await _context.Tasks.SingleOrDefaultAsync(t => t.Id == id);
        }

        public async Task<ToDoTask> AddAsynch(ToDoTask task)
        {
            var createdTask = await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsynch();
            return createdTask.Entity;
        }

        public async Task UpdateAsynch(ToDoTask task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsynch();
            await Task.CompletedTask;
        }

        public async Task DeleteAsynch(ToDoTask task)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsynch();
            await Task.CompletedTask;
        }
    }
}
