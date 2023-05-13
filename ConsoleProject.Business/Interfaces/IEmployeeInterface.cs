using ConsoleProject.Core.Entities;

namespace ConsoleProject.Business.Interfaces;

public interface IEmployeeInterface
{
    //void Create(string name, string surname, double salary);
    void Create(Employee employee);
    void Update(string oldName, string newName, double salary, int id, int departmentId);
    void Delete(int id);
    Employee GetById(int id);
    List<Employee> GetAll();
}
