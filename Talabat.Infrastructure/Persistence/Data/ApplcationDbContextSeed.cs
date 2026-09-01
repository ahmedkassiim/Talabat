using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Talabat.Domain.Entities;

namespace Talabat.Infrastructure.Persistence.Data
{
    public static class ApplcationDbContextSeed
    {
        public static async Task SeedAsync(ApplcationDbContext dbContext)
        {

            if(dbContext.Brands.Count() == 0)
            {
            var filePath = "../Talabat.Infrastructure/Persistence/Data/Fileseeding/brands.json";
            var file = File.ReadAllText(filePath);
            var brands = JsonSerializer.Deserialize<IEnumerable<Brand>>(file);
                if(brands is not null && brands.Count() >0 )
                foreach(var brand in brands)
                {
                      await  dbContext.AddAsync(brand);
                }
              await  dbContext.SaveChangesAsync();
            }
            if(dbContext.Categories.Count() == 0)
            {
            var filePath = "../Talabat.Infrastructure/Persistence/Data/Fileseeding/categories.json";
            var file = File.ReadAllText(filePath);
            var categories = JsonSerializer.Deserialize<IEnumerable<Category>>(file);
                if(categories is not null && categories.Count() >0 )
                foreach(var category in categories)
                {
                      await  dbContext.AddAsync(category);
                }
              await  dbContext.SaveChangesAsync();
            }

            if(dbContext.Products.Count() == 0)
            {
            var filePath = "../Talabat.Infrastructure/Persistence/Data/Fileseeding/products.json";
            var file = File.ReadAllText(filePath);
            var products = JsonSerializer.Deserialize<IEnumerable<Product>>(file);
                if(products is not null && products.Count() >0 )
                foreach(var product in products)
                {
                      await  dbContext.AddAsync(product);
                }
              await  dbContext.SaveChangesAsync();
            }



        }
    }
}
