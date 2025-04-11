using Microsoft.Extensions.Configuration;
using System.Data; 
using MySql.Data.MySqlClient;
using ORM_Dapper.Data;


namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);

            var depRepo = new DepartmentRepository(conn);
            
            depRepo.AddDepartment("Special");
            
            var departments = depRepo.GetAllDepartments();

            foreach (var department in departments)
            {
                Console.WriteLine($"ID: {department.DepartmentID}, Name: {department.Name}");
            }
          
          var prodRepo = new ProductRepository(conn);
          
          prodRepo.AddProduct("JONDGeneric Product", 20.99, 10, false, 300);
          var prod =  prodRepo.GetAllProducts().FirstOrDefault(e => e.Name == "JONDGeneric Product");
          
          prodRepo.UpdateProduct(prod.ProductID, "New Name", 50.00, 10, true, 150);

          prodRepo.DeleteProduct(prod.ProductID);
          

          var products = prodRepo.GetAllProducts();

          foreach (var product in products)
          {
              Console.WriteLine($"ID: {product.ProductID} | NAME: {product.Name} | PRICE: {product.Price} | CATEGORY ID: {product.CategoryID} | SALE: {product.OnSale} STOCK: {product.StockLevel}");
          }
        }
    }
}
