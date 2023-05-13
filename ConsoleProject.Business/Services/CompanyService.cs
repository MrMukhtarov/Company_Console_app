using ConsoleProject.Business.Exceptions;
using ConsoleProject.Business.Helpers;
using ConsoleProject.Business.Interfaces;
using ConsoleProject.Core.Entities;
using ConsoleProjetc.DataAccess.Implementations;

namespace ConsoleProject.Business.Services;

public class CompanyService : ICompanyInterface
{
    CompanyRepository companyRepository { get; }
    DepartmentRepository departmentRepository { get; }

    public CompanyService()
    {
        companyRepository = new CompanyRepository();
        departmentRepository = new DepartmentRepository();
    }
    public void Create(string name)
    {
        string TrimName = name.Trim();
        var exist = companyRepository.GetByName(TrimName);
        if (exist != null)
        {
            throw new AlreadyExistException(Helper.Error["AlreadyExistException"]);
        }
        if (TrimName.Length <= 0)
        {
            throw new SizeException(Helper.Error["SizeException"]);
        }
        Company company = new Company(name);
        companyRepository.Add(company);
    }
    public void Delete(int id)
    {
        var exist = companyRepository.Get(id);
        if (exist != null)
        {
            if (departmentRepository.GetAllCompanyId(id) == null)
            {
                companyRepository.Delete(id);
            }
            else
            {
                throw new ObjectNotFoundException(Helper.Error["ObjectNotFoundException"]);
            }
        }
        else
        {
            throw new ObjectNotFoundException(Helper.Error["ObjectNotFoundException"]);
        }
    }
    public void Update(string oldName, string newName)
    {
        string name = newName.Trim();
        var exist = companyRepository.GetByName(oldName.Trim());
        if (name.Length <= 0)
        {
            throw new SizeException(Helper.Error["SizeException"]);
        }
        if (exist == null)
        {
            throw new ObjectNotFoundException(Helper.Error["ObjectNotFoundException"]);
        }
        if (exist.Name.ToUpper() == newName.ToUpper())
        {
            throw new SameNameException(Helper.Error["SameNameException"]);
        }
        exist.Name = name;
        companyRepository.Update(exist);
    }
    public List<Company> GetAll()
    {
        return companyRepository.GetAll();
    }

    public Company GetById(int id)
    {
        var exist = companyRepository.Get(id);
        if (exist == null)
        {
            throw new ObjectNotFoundException(Helper.Error["ObjectNotFoundException"]);
        }
        return exist;
    }

}
