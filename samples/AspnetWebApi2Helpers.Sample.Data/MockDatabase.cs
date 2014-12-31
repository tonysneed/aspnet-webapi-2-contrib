using System.Collections.Generic;
using AspnetWebApi2Helpers.Sample.Entities;

namespace AspnetWebApi2Helpers.Sample.Data
{
    public static class MockDatabase
    {
        static MockDatabase()
        {
            Categories = new List<Category>
            {
                new Category { CategoryId = 1, CategoryName = "Beverages" },
                new Category { CategoryId = 2, CategoryName = "Condiments" },
                new Category { CategoryId = 3, CategoryName = "Confections" },
                new Category { CategoryId = 4, CategoryName = "Dairy Products" },
                new Category { CategoryId = 5, CategoryName = "Grains/Cereals" },
                new Category { CategoryId = 6, CategoryName = "Meat/Poultry" },
                new Category { CategoryId = 7, CategoryName = "Produce" },
                new Category { CategoryId = 8, CategoryName = "Seafood" },
            };

            Products = new List<Product>
            {
                new Product { ProductId = 1, ProductName = "Chai", CategoryId = 1, Category = Categories[0] },
                new Product { ProductId = 2, ProductName = "Chang", CategoryId = 1, Category = Categories[0] },
                new Product { ProductId = 3, ProductName = "Aniseed Syrup", CategoryId = 2, Category = Categories[1] },
                new Product { ProductId = 4, ProductName = "Chef Anton's Cajun Seasoning", CategoryId = 2, Category = Categories[1] },
                new Product { ProductId = 5, ProductName = "Chef Anton's Gumbo Mix", CategoryId = 2, Category = Categories[1] },
                new Product { ProductId = 6, ProductName = "Grandma's Boysenberry Spread", CategoryId = 2, Category = Categories[1] },
                new Product { ProductId = 7, ProductName = "Uncle Bob's Organic Dried Pears", CategoryId = 7, Category = Categories[6] },
                new Product { ProductId = 8, ProductName = "Northwoods Cranberry Sauce", CategoryId = 2, Category = Categories[1] },
                new Product { ProductId = 9, ProductName = "Mishi Kobe Niku", CategoryId = 6, Category = Categories[5] },
                new Product { ProductId = 10, ProductName = "Ikura", CategoryId = 8, Category = Categories[7] },
            };

            Categories[0].Products.Add(Products[0]);
            Categories[0].Products.Add(Products[1]);
            Categories[1].Products.Add(Products[2]);
            Categories[1].Products.Add(Products[3]);
            Categories[1].Products.Add(Products[4]);
            Categories[1].Products.Add(Products[5]);
            Categories[6].Products.Add(Products[6]);
            Categories[1].Products.Add(Products[7]);
            Categories[5].Products.Add(Products[8]);
            Categories[7].Products.Add(Products[9]);
        }

        public static List<Category> Categories { get; private set; }

        public static List<Product> Products { get; private set; }
    }
}