using ConsoleProject.Business.Services;
using ConsoleProject.Core.Entities;

CompanyService companyService = new CompanyService();
companyService.Create("BErshka");
companyService.Create("BErshk");
companyService.Update("BErshka", "NEwyorker");
companyService.Update("BErshk", "KFC");
foreach (Company i in companyService.GetAll())
{
    Console.WriteLine($"{i.Id} {i.Name}");
}
