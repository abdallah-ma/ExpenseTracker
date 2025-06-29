using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.DAL.Models;
using DemoAPI.Core.Interfaces;
using ExpenseTracker.BLL.Interfaces;
using ExpenseTracker.BLL.Specifications;
using Microsoft.EntityFrameworkCore;
using ExpenseTracker.DAL.Data;
using ExpenseTracker.BLL;

namespace ExpenseTracker.BLL.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
         protected readonly AppDbContext _dbContext;

        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            
        }

        public virtual async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await Task.CompletedTask;
        }

        public async Task<T?> GetAsync(int id)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(X => X.Id == id);
        }



        public async Task<T?> GetAsyncWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T?>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T?>> GetAllAsyncWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public virtual async Task UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await Task.CompletedTask;
        }

        public IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
        }

        async Task IGenericRepository<T>.DeleteAsync(T Entity)
        {
            _dbContext.Set<T>().Remove(Entity);
            await Task.CompletedTask;
        }

        
    }
}
