using ConsoleProject.Core.Interfaces;

namespace ConsoleProject.Core.Entities;

public class Department : IEntitiy
{
    public int Id { get; }
    private static int _id;
    public string Name { get; set; }
    public int EmployeeLimit { get; set; }
    public int CompanyId { get; set; }

    public Department()
    {
        Id = _id;
        _id++;
    }
    public override string ToString()
    {
        return $"{Id} {Name}";
    }
}
