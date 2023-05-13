using ConsoleProject.Core.Interfaces;

namespace ConsoleProject.Core.Entities;

public class Company : IEntitiy
{
    public int Id { get; }
    private static int _id;
    public string Name { get; set; }
    public DateTime date;

    public Company()
    {
        Id = _id;
        _id++;
        //date = DateTime.Now;
    }
    public Company(string name) : this()
    {
        Name = name;
    }
    public override string ToString()
    {
        return $"{Id} {Name} {date}";
    }
}
