using ConsoleProject.Business.Exceptions;
using ConsoleProject.Business.Helpers;
using ConsoleProject.Business.Interfaces;
using ConsoleProject.Core.Entities;
using ConsoleProjetc.DataAccess.Implementations;

namespace ConsoleProject.Business.Services;

public class IDepartmentService : IDepartmentInterface
{
    DepartmentRepository departmentRepository { get; }
    CompanyRepository companyRepository { get; }
    EmployeeRepository employeeRepository { get; }

    public IDepartmentService()
    {
        departmentRepository = new DepartmentRepository();
        companyRepository = new CompanyRepository();
        employeeRepository = new EmployeeRepository();
    }
    public void Create(string name, int limit, int compoanyId)
    {
        string names = name.Trim();
        var exist = departmentRepository.GetByName(names);
        var company = companyRepository.Get(compoanyId);
        if (company == null)
        {
            throw new ObjectNotFoundException(Helper.Error["ObjectNotFoundException"]);
        }
        if (exist != null)
        {
            throw new AlreadyExistException(Helper.Error["AlreadyExistException"]);
        }
        if (limit <= 0)
        {
            throw new LimitDoesNotMatchException(Helper.Error["LimitDoesNotMatchException"]);
        }
        if (names.Length <= 0)
        {
            throw new SizeException(Helper.Error["SizeException"]);
        }
        Department department = new Department(names, limit, compoanyId);
        departmentRepository.Add(department);
    }
    public void Delete(int id)
    {
        var existDepartment = departmentRepository.Get(id);
        if (existDepartment != null)
        {
            departmentRepository.Delete(id);
            //if (employeeRepository.GetAllDeparmentId(id).Count == 0)
            //{
            //}
            //else
            //{
            //    throw new ObjectDoesNotEmptyExcepion(Helper.Error["ObjectDoesNotEmptyExcepion"]);
            //}
        }
        else
        {
            throw new ObjectNotFoundException(Helper.Error["ObjectNotFoundException"]);
        }
    }
    public void UpdateDepartment(string name, string newName, int limit)
    {
        throw new NotImplementedException();
    }
    public List<Department> GetAll()
    {
        return departmentRepository.GetAll();
    }
    public Department GetById(int id)
    {
        var exist = departmentRepository.Get(id);
        if (exist == null)
        {
            throw new ObjectNotFoundException(Helper.Error["ObjectNotFoundException"]);
        }
        return exist;
    }
    public void AddEmployee(Employee employee)
    {
        var existEmployee = employeeRepository.Get(employee.DepartmentId);
        if (existEmployee != null)
        {
            throw new ObjectNotFoundException("Basqasina add olunub");
        }
        existEmployee.DepartmentId = employee.DepartmentId;
    }
    public List<Employee> GetDepartmentEmployees(string name)
    {
        throw new NotImplementedException();
    }
}
