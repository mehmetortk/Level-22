using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.DTOs;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            productManager();
            //categoryManager();
          
        }

        private static void categoryManager()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var entity in categoryManager.GetAll())
            {
                Console.WriteLine(entity.CategoryName);
            }
        }
        private static void productManager()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.GetProductDetails())
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine(product.ProductName+'/'+product.CategoryName+'/'+product.UnitsInStock);
            }
        }
    }
}
