using ConsoleProject.Core.Entities;

namespace ConsoleProject.Business.Interfaces;

public interface IEmployeeInterface
{
    void Create(Employee employee);
    void Update(string name, string surname, double salary, int id, int departmentId);
    void Delete(int id);
    Employee GetById(int id);
    List<Employee> GetAll();
}
