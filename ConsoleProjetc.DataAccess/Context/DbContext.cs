using ConsoleProject.Core.Entities;

namespace ConsoleProjetc.DataAccess.Context;

public static class DbContext
{
    public static List<Company> Companys { get; set; } = new List<Company>();
    public static List<Department> Departments { get; set; } = new List<Department>();
    public static List<Employee> Employees { get; set; } = new List<Employee>();
}
