using ConsoleProject.Business.Exceptions;
using ConsoleProject.Business.Helpers;
using ConsoleProject.Business.Interfaces;
using ConsoleProject.Core.Entities;
using ConsoleProjetc.DataAccess.Implementations;

namespace ConsoleProject.Business.Services;

public class EmployeeService : IEmployeeInterface
{
    public EmployeeRepository employeeRepository { get; }
    public DepartmentRepository departmentRepository { get; }
    public EmployeeService()
    {
        employeeRepository = new EmployeeRepository();
        departmentRepository = new DepartmentRepository();
    }
    public void Create(Employee employee)
    {
        string NameTrim = employee.Name.Trim();
        string SurnameTrim = employee.Surname.Trim();
        if (NameTrim.Length < 2)
        {
            throw new SizeException(Helper.Error["SizeException"]);
        }
        if (!NameTrim.IsOnlyLetters())
        {
            throw new PatternDoesNotMatchException(Helper.Error["PatternDoesNotMatchException"]);
        }
        if (!string.IsNullOrWhiteSpace(SurnameTrim))
        {
            if (!SurnameTrim.IsOnlyLetters())
            {
                throw new PatternDoesNotMatchException(Helper.Error["PatternDoesNotMatchException"]);
            }
        }
        if (employee.Salary <= 0)
        {
            throw new CannotBeLessThanZeroException(Helper.Error["CannotBeLessThanZeroException"]);
        }
        employeeRepository.Add(employee);
    }
    public void Delete(int id)
    {
        var exist = employeeRepository.Get(id);
        if (exist == null)
        {
            throw new ObjectNotFoundException(Helper.Error["ObjectNotFoundException"]);
        }
        employeeRepository.Delete(id);
    }
    public void Update(string name, string surname, double salary, int id, int departmentId)
    {
        var exist = employeeRepository.Get(id);
        string nameTrim = name.Trim();
        string SurnameTrim = surname.Trim();
        var existDepartmentId = departmentRepository.Get(departmentId);
        if (exist == null)
        {
            throw new ObjectNotFoundException(Helper.Error["ObjectNotFoundException"]);
        }
        if (nameTrim.Length < 2)
        {
            throw new SizeException(Helper.Error["SizeException"]);
        }
        if (!nameTrim.IsOnlyLetters())
        {
            throw new PatternDoesNotMatchException(Helper.Error["PatternDoesNotMatchException"]);
        }
        if (!string.IsNullOrWhiteSpace(SurnameTrim))
        {
            if (!SurnameTrim.IsOnlyLetters())
            {
                throw new PatternDoesNotMatchException(Helper.Error["PatternDoesNotMatchException"]);
            }
        }
        if (salary <= 0)
        {
            throw new CannotBeLessThanZeroException(Helper.Error["CannotBeLessThanZeroException"]);
        }
        if (existDepartmentId == null)
        {
            throw new ObjectNotFoundException(Helper.Error["ObjectNotFoundException"]);
        }
        exist.Surname = surname;
        exist.DepartmentId = departmentId;
        exist.Salary = salary;
        exist.Name = name;
        employeeRepository.Update(exist);
    }
    public List<Employee> GetAll()
    {
        return employeeRepository.GetAll();
    }

    public Employee GetById(int id)
    {
        var exist = employeeRepository.Get(id);
        if (exist == null)
        {
            throw new ObjectNotFoundException(Helper.Error["ObjectNotFoundException"]);
        }
        return exist;
    }

}
