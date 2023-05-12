using ConsoleProject.Core.Interfaces;

namespace ConsoleProject.Core.Entities;

public class Company : IEntitiy
{
    public int Id { get; }
    private static int _id;
    public string Name { get; set; }

    public Company()
    {
        Id = _id;
        _id++;
    }
}
