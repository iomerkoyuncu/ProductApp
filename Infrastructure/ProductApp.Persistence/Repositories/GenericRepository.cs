using Microsoft.EntityFrameworkCore;
using ProductApp.Application.Interfaces.Repositories;
using ProductApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProductApp.Persistence.Contexts;
using ProductApp.Domain.Entities;

namespace ProductApp.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ProductAppDbContext dbContext;

        public GenericRepository(ProductAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<T>> GetAll()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {   
            dbContext.Set<T>().Remove(entity);
            await dbContext.SaveChangesAsync();
        }


    }
}
