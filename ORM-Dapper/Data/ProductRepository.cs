using System.Data;
using ORM_Dapper.Models;
using Dapper;

namespace ORM_Dapper.Data;

public class ProductRepository : IProductRepository
{
    private readonly IDbConnection _connection;

    public ProductRepository(IDbConnection connection)
    {
        _connection = connection;
    }
    
    public IEnumerable<Product> GetAllProducts()
    {
        return _connection.Query<Product>("SELECT * FROM products;");
    }

    public void AddProduct(string name, double price, int categoryID, bool onSale, int stockLevel)
    {
        _connection.Execute(
            "INSERT INTO products (Name, Price, CategoryID, OnSale, StockLevel) VALUES (@name, @price, @categoryID, @onSale, @stockLevel);",
            new {name, price, categoryID, onSale, stockLevel});
    }

    public void UpdateProduct(int productID, string name, double price, int categoryID, bool onSale, int stockLevel)
    {
        _connection.Execute(
            "UPDATE products SET Name = @name, Price = @price, CategoryID = @categoryID, OnSale = @onSale, StockLevel = @stockLevel WHERE ProductID = @productId;",
            new {name, price, categoryID, onSale, stockLevel, productID});
    }

    public void DeleteProduct(int productID)
    {
        _connection.Execute("DELETE FROM reviews WHERE ProductID = @productId;", new {productID});
        _connection.Execute("DELETE FROM sales WHERE ProductID = @productId;", new {productID});
        _connection.Execute("DELETE FROM products WHERE ProductID = @productId;", new {productID});
    }
}