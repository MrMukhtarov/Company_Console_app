using ConsoleProject.Business.Services;
using ConsoleProject.Core.Entities;

CompanyService companyService = new CompanyService();
companyService.Create("BErshka");
companyService.Create("BErshk");
companyService.Update("BErshka", "NEwyorker");
companyService.Update("BErshk", "KFC");
companyService.Create("dolma");
//companyService.Delete(0);
//Console.WriteLine(companyService.GetById(1));
foreach (Company i in companyService.GetAll())
{
    Console.WriteLine($"{i.Id} {i.Name} {i.date}");
}


