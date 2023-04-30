using ProductApp.Persistence.Repositories;
using ProductApp.Application.Interfaces.Repositories;
using ProductApp.Domain.Entities;
using ProductApp.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProductApp.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ProductAppDbContext dbContext;

        public ProductRepository(ProductAppDbContext dbContext): base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Product>> GetAllByCatalogId(Guid catalogId)
        {
            return await dbContext.Set<Product>().Where(p => p.CatalogId == catalogId).ToListAsync();
        }
    }
}
