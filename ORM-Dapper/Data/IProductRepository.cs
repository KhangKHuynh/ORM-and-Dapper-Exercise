using ORM_Dapper.Models;

namespace ORM_Dapper.Data;

public interface IProductRepository
{
    public IEnumerable<Product> GetAllProducts();
    public void AddProduct(string name, double price, int categoryID, bool onSale, int stockLevel);
    public void UpdateProduct(int productID, string name, double price, int categoryID, bool onSale, int stockLevel);
    public void DeleteProduct(int productID);
}

