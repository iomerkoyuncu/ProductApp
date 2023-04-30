using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductApp.Persistence.Contexts;
using ProductApp.Persistence.Repositories;
using ProductApp.Application.Interfaces.Repositories;

namespace ProductApp.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services) {
            services.AddDbContext<ProductAppDbContext>(options => options.UseNpgsql("User ID=postgres;Password=root;Host=localhost;Port=5432;Database=productapp;") );
            services.AddTransient<IProductRepository, ProductRepository>();

        }
    }
}
