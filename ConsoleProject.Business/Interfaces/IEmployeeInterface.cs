using ConsoleProject.Core.Entities;

namespace ConsoleProject.Business.Interfaces;

public interface IEmployeeInterface
{
    void CreateEmployee(Employee employee);
    void UpdateEmployee(string name, string surname, double salary, int id, int departmentId);
    void DeleteEmployee(int id);
    Employee EmployeeGetById(int id);
    List<Employee> EmployeeGetAll();
}
