using ConsoleProject.Core.Entities;

namespace ConsoleProject.Business.Interfaces;

internal interface IDepartmentInterface
{
    void CreateDepartment(string name, int limit, int compoanyId);
    void UpdateDepartment(string name, string newName, int limit);
    void DeleteDepartment(int id);
    Department DepartmentGetById(int id);
    List<Department> DepartmentGetAll();
    void AddEmployee(Employee employee,int departmentId);
    List<Employee> GetDepartmentEmployees(string name);
}
