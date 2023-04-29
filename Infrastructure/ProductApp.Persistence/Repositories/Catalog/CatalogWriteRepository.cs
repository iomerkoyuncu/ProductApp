﻿using ProductApp.Application.Repositories;
using ProductApp.Domain.Entities;
using ProductApp.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Persistence.Repositories
{
    public class CatalogWriteRepository : WriteRepository<Catalog>, ICatalogWriteRepository
    {
        public CatalogWriteRepository(ProductAppDbContext context) : base(context)
        {
        }
    }
}
