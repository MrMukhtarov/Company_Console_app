using ConsoleProject.Business.Services;
using ConsoleProject.Core.Entities;

CompanyService companyService = new CompanyService();
companyService.Create("BErshka");
companyService.Create("BErshk");
companyService.Create("dolma");
//companyService.Update("BErshka", "NEwyorker");
//companyService.Update("BErshk", "KFC");
//Console.WriteLine(companyService.GetById(1));

IDepartmentService departmentService = new IDepartmentService();
departmentService.Create("Backend", 2, 2);
//departmentService.Delete(0);
//companyService.Delete(2);

foreach (Company i in companyService.GetAll())  
{
    Console.WriteLine($"{i.Id} {i.Name} {i.date}");
}
foreach(var i in companyService.GetAllDepartment("dolma"))
{
    Console.WriteLine(i);
}
foreach(var i in departmentService.GetAll())
{
    Console.WriteLine(i.Name + " " + i.EmployeeLimit);
}
Console.WriteLine(departmentService.GetById(0));