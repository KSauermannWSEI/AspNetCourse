using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IPricesRepository
    {
        Task<int> AddAsync(Price item);
        Task<bool> DeleteAsync(int id);
        void Dispose();
        IQueryable<Price> FindBy(Expression<Func<Price, bool>> predicate);
        Task<Price> GetAsync(int id);
        Task<List<Price>> GetListAsync();
        Task SaveChangesAsync();
        Task<bool> UpdateAsync(Price item);
    }
}