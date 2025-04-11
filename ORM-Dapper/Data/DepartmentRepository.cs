using System.Data;
using Dapper;
using ORM_Dapper.Models;

namespace ORM_Dapper.Data;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly IDbConnection _connection;

    public DepartmentRepository(IDbConnection connection)
    {
        _connection = connection;
    }
    
    public IEnumerable<Department> GetAllDepartments()
    {
        return _connection.Query<Department>("SELECT * FROM departments;");
    }

    public void AddDepartment(string name)
    {
        _connection.Execute("INSERT INTO departments (Name) VALUES (@name);", new { name });
    }
}