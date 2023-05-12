using ConsoleProject.Core.Interfaces;

namespace ConsoleProjetc.DataAccess.Interfaces;

public interface IRepostory<T> where T : IEntitiy
{
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    List<T> GetAll();
    T? Get(int id);
}
