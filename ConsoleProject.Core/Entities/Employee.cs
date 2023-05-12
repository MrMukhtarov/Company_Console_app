using ConsoleProject.Core.Interfaces;

namespace ConsoleProject.Core.Entities;

public class Employee : IEntitiy
{
    public int Id { get; }
    private static int _id;
    public double Salary { get; set; }
    public string Surname { get; set; }
    public string Name { get; set; }
    public int DepartmentId { get; set; }

    public Employee()
    {
        Id = _id;
        _id++;
    }
    public Employee(string name, string surname, double salary) : this()
    {
        Name = name;
        Salary = salary;
        Surname = surname;
    }
    public override string ToString()
    {
        return $"{Id} {Name} {Surname}";
    }
}
