using ConsoleProject.Core.Entities;
using ConsoleProjetc.DataAccess.Context;
using ConsoleProjetc.DataAccess.Interfaces;

namespace ConsoleProjetc.DataAccess.Implementations;

public class DepartmentRepository : IRepostory<Department>
{
    public void Add(Department entity)
    {
        DbContext.Departments.Add(entity);
    }

    public void Delete(Department entity)
    {
        DbContext.Departments.Remove(entity);
    }
    public void Update(Department entity)
    {
        Department? department = DbContext.Departments.Find(d => d.Id == entity.Id);
        department.Name = entity.Name;
        department.EmployeeLimit = entity.EmployeeLimit;
    }
    public Department? Get(int id)
    {
        return DbContext.Departments.Find(d => d.Id == id);
    }

    public List<Department> GetAll()
    {
        return DbContext.Departments;
    }

}
