using ConsoleProject.Core.Entities;

namespace ConsoleProject.Business.Interfaces;

public interface ICompanyInterface
{
    void Create(string name);
    void Update(int id);
    void Delete(int id);
    Company GetById(int id);
    List<Company> GetAll();
}
