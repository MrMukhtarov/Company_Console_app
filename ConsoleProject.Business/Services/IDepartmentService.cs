﻿using ConsoleProject.Business.Exceptions;
using ConsoleProject.Business.Helpers;
using ConsoleProject.Business.Interfaces;
using ConsoleProject.Core.Entities;
using ConsoleProjetc.DataAccess.Context;
using ConsoleProjetc.DataAccess.Implementations;

namespace ConsoleProject.Business.Services;

public class IDepartmentService : IDepartmentInterface
{
    public DepartmentRepository departmentRepository { get; }
    public CompanyRepository companyRepository { get; }
    public EmployeeRepository employeeRepository { get; }

    public IDepartmentService()
    {
        departmentRepository = new DepartmentRepository();
        companyRepository = new CompanyRepository();
        employeeRepository = new EmployeeRepository();
    }
    public void CreateDepartment(string name, int limit, int compoanyId)
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
    public void DeleteDepartment(int id)
    {
        var existDepartment = departmentRepository.Get(id);
        if (existDepartment != null)
        {
            if (employeeRepository.GetAllDeparmentId(id).Count == 0)
            {
                departmentRepository.Delete(id);
            }
            else
            {
                throw new ObjectDoesNotEmptyExcepion(Helper.Error["ObjectDoesNotEmptyExcepion"]);
            }
        }
        else
        {
            throw new ObjectNotFoundException(Helper.Error["ObjectNotFoundException"]);
        }
    }
    public void UpdateDepartment(string name, string newName, int limit)
    {
        var existName = departmentRepository.GetByName(name.Trim());
        if (existName == null)
        {
            throw new ObjectNotFoundException(Helper.Error["ObjectNotFoundException"]);
        }
        string newNameTrim = newName.Trim();
        if (name.Trim().ToUpper() == newNameTrim.ToUpper())
        {
            throw new SameNameException(Helper.Error["SameNameException"]);
        }
        foreach(var i in DbContext.Departments)
        {
            if(i.Name.ToLower() == newNameTrim.ToLower())
            {
                throw new AlreadyExistException(Helper.Error["AlreadyExistException"]);
            }
        }
        if (GetDepartmentEmployees(name).Count > limit)
        {
            throw new LimitDoesNotMatchException(Helper.Error["LimitDoesNotMatchException"]);
        }
        if (limit <= 0)
        {
            throw new LimitDoesNotMatchException(Helper.Error["LimitDoesNotMatchException"]);
        }
        existName.Name = newName;
        existName.EmployeeLimit = limit;
        departmentRepository.Update(existName);
    }
    public List<Department> DepartmentGetAll()
    {
        return departmentRepository.GetAll();
    }
    public Department DepartmentGetById(int id)
    {
        var exist = departmentRepository.Get(id);
        if (exist == null)
        {
            throw new ObjectNotFoundException(Helper.Error["ObjectNotFoundException"]);
        }
        return exist;
    }
    public void AddEmployee(Employee employee, int departmentId)
    {
        if (employee.DepartmentId != 0)
        {
            throw new EmployeeHasDepartmentIdException(Helper.Error["EmployeeHasDepartmentIdException"]);
        }
        var existDepartmentid = departmentRepository.Get(departmentId);
        if (existDepartmentid == null)
        {
            throw new ObjectNotFoundException(Helper.Error["ObjectNotFoundException"]);
        }
        if (GetDepartmentEmployees(existDepartmentid.Name).Count > existDepartmentid.EmployeeLimit)
        {
            throw new CapacityLimitException(Helper.Error["CapacityLimitException"]);
        }
        employee.DepartmentId = departmentId;
    }
    public List<Employee> GetDepartmentEmployees(string name)
    {
        var departmentId = departmentRepository.GetByName(name);
        if (departmentId == null)
        {
            throw new ObjectNotFoundException(Helper.Error["ObjectNotFoundException"]);
        }
        var employeeId = employeeRepository.GetAllDeparmentId(departmentId.Id);
        return employeeId;
    }
}
