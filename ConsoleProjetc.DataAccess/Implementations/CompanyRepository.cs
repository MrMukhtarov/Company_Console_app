using ConsoleProject.Core.Entities;
using ConsoleProjetc.DataAccess.Context;
using ConsoleProjetc.DataAccess.Interfaces;

namespace ConsoleProjetc.DataAccess.Implementations;

public class CompanyRepository : IRepostory<Company>
{
    public void Add(Company entity)
    {
        DbContext.Companys.Add(entity);
    }

    public void Delete(Company entity)
    {
        DbContext.Companys.Remove(entity);
    }
    public void Update(Company entity)
    {
        Company? company = DbContext.Companys.Find(c => c.Id == entity.Id);
        company.Name = entity.Name;
    }
    public Company? Get(int id)
    {
        return DbContext.Companys.Find(c => c.Id == id);
    }

    public List<Company> GetAll()
    {
        return DbContext.Companys;
    }

}
