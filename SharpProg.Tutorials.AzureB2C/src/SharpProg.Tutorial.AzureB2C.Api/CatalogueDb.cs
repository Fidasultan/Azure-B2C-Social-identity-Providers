using SharpProg.Tutorials.AzureB2C.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpProg.Tutorials.AzureB2C.Api
{
    public static class CatalogueDb
    {
        public static List<Product> Products => new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Test Product 1",
                Description = "This is test product 1",
                AvailableQuantity = 10,
                Price = 99.99m,

            },
            new Product
            {
                Id = 1,
                Name = "Test Product 2",
                Description = "This is test product 2",
                AvailableQuantity = 15,
                Price = 124.99m,

            },
            new Product
            {
                Id = 1,
                Name = "Test Product 3",
                Description = "This is test product 3",
                AvailableQuantity = 8,
                Price = 212.99m,

            }
        };
    }
}
