using ORM_Dapper.Models;

namespace ORM_Dapper.Data;

public interface IDepartmentRepository
{
    public IEnumerable<Department> GetAllDepartments();
    public void AddDepartment(string name);
}