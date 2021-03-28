using Domain.Models;
using EntityHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IRepository<T> where T: Entity
    {
        Task<T> GetAsync(int id);
        Task<List<T>> GetListAsync();
        Task<int> AddAsync(T item);
        Task<bool> UpdateAsync(T item);
        Task<bool> DeleteAsync(int id);
        void Dispose();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);        
        Task SaveChangesAsync();        
    }
}