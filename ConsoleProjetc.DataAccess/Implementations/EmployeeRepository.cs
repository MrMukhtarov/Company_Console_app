using ConsoleProject.Core.Entities;
using ConsoleProjetc.DataAccess.Context;
using ConsoleProjetc.DataAccess.Interfaces;

namespace ConsoleProjetc.DataAccess.Implementations;

public class EmployeeRepository : IRepostory<Employee>
{
    public void Add(Employee entity)
    {
        DbContext.Employees.Add(entity);
    }

    public void Delete(int id)
    {
        Employee? employee = DbContext.Employees.Find(e => e.Id == id);
        DbContext.Employees.Remove(employee);
    }

    public void Update(Employee entity)
    {
        Employee? employee = DbContext.Employees.Find(e => e.Id == entity.Id);
        employee.Name = entity.Name;
        employee.Surname = entity.Surname;
        employee.Salary = entity.Salary;
    }
    public Employee? Get(int id)
    {
        return DbContext.Employees.Find(e => e.Id == id);
    }

    public List<Employee> GetAll()
    {
        return DbContext.Employees;
    }

}
