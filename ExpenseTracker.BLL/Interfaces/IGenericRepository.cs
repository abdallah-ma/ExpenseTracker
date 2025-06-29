using ExpenseTracker.DAL.Models;
using ExpenseTracker.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAPI.Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {

        public  Task<T> GetAsyncWithSpec(ISpecification<T> spec);


        public Task<IEnumerable<T>> GetAllAsync();

        public Task<IEnumerable<T>> GetAllAsyncWithSpec(ISpecification<T> spec);


        public Task<T> GetAsync(int id);


        public Task UpdateAsync(T entity);

        public Task AddAsync(T Entity);

        public Task DeleteAsync(T Entity);




    }
}
