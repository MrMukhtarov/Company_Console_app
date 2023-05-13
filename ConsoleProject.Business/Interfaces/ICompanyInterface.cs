using ConsoleProject.Core.Entities;

namespace ConsoleProject.Business.Interfaces;

public interface ICompanyInterface
{
    void Create(string name);
    void Update(string oldName, string newName);
    void Delete(int id);
    Company GetById(int id);
    List<Company> GetAll();
    List<Department> GetAllDepartment(string companyName);
}
