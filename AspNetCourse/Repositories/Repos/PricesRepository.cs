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
    public class PricesRepository : IDisposable, IPricesRepository
    {
        private readonly DbContext context;
        private readonly DbSet<Price> dbSet = null;

        public PricesRepository(DbContext context)
        {
            this.context = context;
            dbSet = context.Set<Price>();
        }

        public async Task<Price> GetAsync(int id)
        {
            //return await context.Set<Price>().FindAsync(id);
            return await dbSet.FindAsync(id);
        }

        public async Task<List<Price>> GetListAsync()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }
        public async Task<int> AddAsync(Price item)
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
        public async Task<bool> UpdateAsync(Price item)
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
        public IQueryable<Price> FindBy(Expression<Func<Price, bool>> predicate)
        {
            //return dbSet.Where(p => p.PriceValue > 50 && p.PriceValue < 70 || p.Currency != "PLN").AsQueryable();
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
