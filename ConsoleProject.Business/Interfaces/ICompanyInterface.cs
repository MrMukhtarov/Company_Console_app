using ConsoleProject.Core.Entities;

namespace ConsoleProject.Business.Interfaces;

public interface ICompanyInterface
{
    void CreateCompany(string name);
    void UpdateCompany(string oldName, string newName);
    void DeleteCompany(int id);
    Company CompanyGetById(int id);
    List<Company> CompanyGetAll();
    List<Department> GetAllDepartment(string companyName);
}
