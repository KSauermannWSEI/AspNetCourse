using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repos
{
    public class Repository<T> : IDisposable, IRepository<T> where T: EntityHelper.Entity
    {
        private readonly DbContext context;
        private readonly DbSet<T> dbSet = null;

        public Repository(DbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public async Task<T> GetAsync(int id)
        {
            //return await context.Set<T>().FindAsync(id);
            return await dbSet.FindAsync(id);
        }

        public async Task<List<T>> GetListAsync()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }
        public async Task<int> AddAsync(T item)
        {
            try
            {
                await dbSet.AddAsync(item);
                return item.Id;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        public async Task<bool> UpdateAsync(T item)
        {
            try
            {
                await Task.Run(() => dbSet.Update(item));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var item = await GetAsync(id);
            if (item != null)
            {
                dbSet.Remove(item);
                return true;
            }
            return false;
        }
        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            //return dbSet.Where(p => p.TValue > 50 && p.TValue < 70 || p.Currency != "PLN").AsQueryable();
            return dbSet.Where(predicate).AsQueryable();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
