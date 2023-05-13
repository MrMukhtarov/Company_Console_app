using ConsoleProject.Business.Services;
using ConsoleProject.Core.Entities;

CompanyService companyService = new CompanyService();
companyService.Create("BErshka");
companyService.Create("BErshk");
companyService.Update("BErshka", "NEwyorker");
companyService.Update("BErshk", "KFC");
companyService.Create("dolma");
//Console.WriteLine(companyService.GetById(1));

IDepartmentService departmentService = new IDepartmentService();
departmentService.Create("Backend", 2, 2);
departmentService.Delete(0);
companyService.Delete(2);

foreach (Company i in companyService.GetAll())  
{
    Console.WriteLine($"{i.Id} {i.Name} {i.date}");
}