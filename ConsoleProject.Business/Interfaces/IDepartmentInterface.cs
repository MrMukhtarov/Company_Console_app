using ConsoleProject.Core.Entities;

namespace ConsoleProject.Business.Interfaces;

internal interface IDepartmentInterface
{
    void Create(string name, int limit, int compoanyId);
    void UpdateDepartment(string name, string newName, int limit);
    void Delete(int id);
    Department GetById(int id);
    List<Department> GetAll();
    void AddEmployee(Employee employee);
    List<Employee> GetDepartmentEmployees(string name);
}
