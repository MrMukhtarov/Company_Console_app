using ConsoleProject.Business.Services;
using ConsoleProject.Core.Entities;

//CompanyService company = new CompanyService();
//company.Create("NctLmn");
//company.Create("NctLmnnct");
////company.Delete(2);
//company.Update("NctLmnnct", "myau");
//Console.WriteLine("GEt by id");
//Console.WriteLine(company.GetById(2));

//foreach (var i in company.GetAll())
//{
//    Console.WriteLine(i);
//}


//Console.WriteLine("==========");
//Console.WriteLine("Employee");
//Console.WriteLine("==========");
//Employee employee1 = new Employee("Nicat","Muxtarov",12500);
//Employee employee2 = new Employee("Leman", "Mammadly", 12500);
//Employee employee3 = new Employee("Lomon", "Muxtarova", 12500);
//EmployeeService employeeService = new EmployeeService();
//employeeService.Create(employee1);
//employeeService.Create(employee2);
//employeeService.Create(employee3);

//Console.WriteLine("==========");
//Console.WriteLine("Department");
//Console.WriteLine("==========");
//IDepartmentService department = new IDepartmentService();
//department.Create("Backend", 2, 2);
//department.Create("Frontend", 2, 2);
//department.UpdateDepartment("Frontend", "React", 3);
//department.AddEmployee(employee1, 2);
//department.AddEmployee(employee2, 2);
//department.AddEmployee(employee3, 2);
//foreach (var i in department.GetAll())
//{
//    Console.WriteLine(i);
//}

//Console.WriteLine("Myau departments");
//foreach (var i in company.GetAllDepartment("myau"))
//{
//    Console.WriteLine(i);
//}
//Console.WriteLine("GET Department Employee");
//foreach (var i in department.GetDepartmentEmployees("Reacts"))
//{
//    Console.WriteLine(i);
//}


CompanyService companyService = new CompanyService();
IDepartmentService departmentService = new IDepartmentService();
EmployeeService employeeService = new EmployeeService();
do
{
    Console.WriteLine("====Welcome Company Management System====\n");
    Console.WriteLine("Enter number what you want opearation\n");
    Console.WriteLine("1. Copmpany Yaratmaq");
    Console.WriteLine("2. Compyany`de deyişiklik etmek");
    Console.WriteLine("3. Company silmek");
    Console.WriteLine("4. Bütün Company`lerin siyahısını çıxarmaq");
    Console.WriteLine("5. ID`sine göre Company`lere baxmaq");
    Console.WriteLine("6. Seçdiyiniz Company`de olan Departmentlerin siyasına baxmaq");
    Console.WriteLine("7. Department yaratmaq");
    Console.WriteLine("8. Departmentde deyisiklik etmek");
    Console.WriteLine("9. Departmenti silmek");
    Console.WriteLine("10. Butun Departmentlerin siyashisina baxmaq");
    Console.WriteLine("11. ID`sine gore Departmente baxmaq");
    Console.WriteLine("12. Departmente Employee elave etmek");
    Console.WriteLine("13. Department adina gore iscilere baxmaq");
    Console.WriteLine("14. Employee yaratmaq");
    Console.WriteLine("15. Employee silmek");
    Console.WriteLine("16. Employee`de deyisiklik etmek");
    Console.WriteLine("17. Employee`lerin siyahisina baxmaq");
    Console.WriteLine("18. ID`sine gore Employee axtarmaq");
    string choose = Console.ReadLine();
    int chooseNum;
} while (false);




























