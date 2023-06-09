﻿using ProductApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Interfaces.Repositories
{
    public interface IProductRepository: IGenericRepository<Product>
    {
        Task<List<Product>> GetAllByCatalogId(Guid catalogId);
    }
}
