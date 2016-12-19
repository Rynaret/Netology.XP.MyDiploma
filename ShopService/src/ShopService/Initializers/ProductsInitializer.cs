using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ShopService.Conventions;
using ShopService.Entities;

namespace ShopService.Initializers
{
    public class ProductsInitializer : IInitializable
    {
        private readonly DbContext _dbContext;

        public ProductsInitializer(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Order => 1;
        public void Initialize()
        {
            _dbContext.Set<Product>().AddRange(new List<Product>
            {
                new Product
                {
                    Name = "Бритвенный станок",
                    Price = 1
                }, 
                new Product
                {
                    Name = "Гель для бритья",
                    Price = 8
                },
                new Product
                {
                    Name = "Средство после бритья",
                    Price = 10
                }
            });
            _dbContext.SaveChanges();
        }
    }
}