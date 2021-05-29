using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System; 

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //NewMethod();
            ProductTest();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            var category = categoryManager.CategoryGetById(3);
            Console.Write(category.CategoryName);
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            var result = productManager.GetProductDetails();
            if (result.Success == true)
            {
                foreach (var product in result.Data )
                {
                    Console.WriteLine(product.ProductName + " - " + product.CategoryName);
                }
            }
           
        }
    }
}
