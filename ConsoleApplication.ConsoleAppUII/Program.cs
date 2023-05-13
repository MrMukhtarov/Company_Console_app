using ConsoleProject.Business.Services;
using ConsoleProject.Core.Entities;

CompanyService companyService = new CompanyService();
companyService.Create("BErshka");
companyService.Create("BErshk");
companyService.Create("dolma");
//companyService.Update("BErshka", "NEwyorker");
//companyService.Update("BErshk", "KFC");
//Console.WriteLine(companyService.GetById(1));

//departmentService.Delete(0);
//companyService.Delete(2);

foreach (Company i in companyService.GetAll())  
{
    Console.WriteLine($"{i.Id} {i.Name} {i.date}");
}
foreach(var i in companyService.GetAllDepartment("BErshka"))
{
    Console.WriteLine(i);
}
//IDepartmentService departmentService = new IDepartmentService();
//departmentService.Create("Backend", 2, 2);
//departmentService.Create("Forntend", 2, 2);
//foreach(var i in departmentService.GetAll())
//{
//    Console.WriteLine(i.Name + " " + i.EmployeeLimit);
//}
//Console.WriteLine(departmentService.GetById(0));

//EmployeeService employeeService = new EmployeeService();

//Employee employee = new Employee("nicat"," ",15000);

//Employee employee1 = new Employee("nicat"," ",15000);
//employeeService.Create(employee);
//departmentService.AddEmployee(employee1,0);
//departmentService.AddEmployee(employee1,0);

IDepartmentService department = new IDepartmentService();
department.Create("Backend", 2, 1);
department.Create("Frontend", 2, 1);
department.Create("IT", 3, 1);

Employee employee1 = new Employee("Nicat","Muxtarov",125.59);
Employee employee2 = new Employee("Leman","Muxtarova",125.59);
Employee employee3 = new Employee("Leman","Muxtarova",125.59);
Employee employee4 = new Employee("Leman","Muxtarova",125.59);

EmployeeService employeeService = new EmployeeService();
employeeService.Create(employee1);
employeeService.Create(employee2);
employeeService.Create(employee3);
employeeService.Create(employee4);
department.AddEmployee(employee1, 1);
department.AddEmployee(employee2, 1);
department.AddEmployee(employee3, 2);
employeeService.Update("Nijat", "Mukhtarov", 125000, 1, 2);
employeeService.Delete(1);
Console.WriteLine("BAckend");
foreach (var i in department.GetDepartmentEmployees("Backend"))
{
    Console.WriteLine(i);
}
Console.WriteLine("Forntend");
foreach (var i in department.GetDepartmentEmployees("Frontend"))
{
    Console.WriteLine(i);
}
//department.UpdateDepartment("Backen", "Backend", 3);
