using ConsoleProject.Business.Helpers;
using ConsoleProject.Business.Services;
using ConsoleProject.Core.Entities;
using ConsoleProjetc.DataAccess.Context;
using ConsoleProjetc.DataAccess.Implementations;

CompanyService companyService = new CompanyService();
IDepartmentService departmentService = new IDepartmentService();
EmployeeService employeeService = new EmployeeService();
DepartmentRepository departmentRepository = new DepartmentRepository();
CompanyRepository companyRepository = new CompanyRepository();
EmployeeRepository employeeRepository = new EmployeeRepository();

do
{
    Console.WriteLine("====Welcome Company Management System====\n");
    Console.WriteLine("Etmek istediyiniz emeliyyatin nomresini secin\n");
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
    Console.WriteLine("19. Sistemden cix");
    string? choose = Console.ReadLine();
    int chooseNum;
    while (!int.TryParse(choose, out chooseNum) || chooseNum > 19 || chooseNum < 1)
    {
        Console.WriteLine("Zehmet olmasa duzgun secim edin");
        choose = Console.ReadLine();
    }
    Console.Clear();
    switch (chooseNum)
    {
        case 1:
            Console.Clear();
            CreateCompany(companyService);
            break;
        case 2:
            Console.Clear();
            UpdateCompany(companyService);
            break;
        case 3:
            Console.Clear();
            DeleteCompany(companyService);
            break;
        case 4:
            Console.Clear();
            CompanyGetAll(companyService);
            break;
        case 5:
            Console.Clear();
            CompanyGetById(companyService);
            break;
        case 6:
            Console.Clear();
            GetAllDepartment(companyService);
            break;
        case 7:
            Console.Clear();
            CreateDepartment(departmentService);
            break;
        case 8:
            Console.Clear();
            UpdateDepartment(departmentService);
            break;
        case 9:
            Console.Clear();
            DeleteDepartment(departmentService);
            break;
        case 10:
            Console.Clear();
            DepartmentGetAll(departmentService);
            break;
        case 11:
            Console.Clear();
            DepartmentGetById(departmentService);
            break;
        case 12:
            Console.Clear();
            AddEmployee(departmentService);
            break;
        case 13:
            Console.Clear();
            GetDepartmentEmployees(departmentService);
            break;
        case 14:
            Console.Clear();
            CreateEmployee(employeeService);
            break;
        case 15:
            Console.Clear();
            DeleteEmployee(employeeService);
            break;
        case 16:
            Console.Clear();
            UpdateEmployee(employeeService);
            break;
        case 17:
            Console.Clear();
            EmployeeGetAll(employeeService);
            break;
        case 18:
            Console.Clear();
            EmployeeGetById(employeeService);
            break;
        case 0:
            return;
    }
} while (true);

void DeleteEmployee(EmployeeService employeeService)
{
    int id;
    bool check = false;

    do
    {
        Console.WriteLine("Silmek istediyiniz Employenin idsni secin\n");
        foreach (var d in DbContext.Employees)
        {
            Console.WriteLine($"Employenin ID`si: {d.Id} Employenin adi: {d.Name} Employenin Soyadi: {d.Surname}\n");
        }
        id = int.Parse(Console.ReadLine());

        var exist = employeeRepository.Get(id);

        if (exist != null)
        {
            check = true;
        }
        else
        {
            Console.WriteLine("Bu id`li Employee yoxdur!");
        }
    } while (!check);
    employeeService.DeleteEmployee(id);
}

void UpdateEmployee(EmployeeService employeeService)
{
    string name, surname;
    double salary;
    int id;
    int departmentId;
    bool check = false;

    do
    {
        Console.WriteLine("Deyismek istediyiniz Employenin ID`sni daxil edin");
        foreach (var d in DbContext.Employees)
        {
            Console.WriteLine($"Employenin ID`si: {d.Id} Employenin adi: {d.Name}\n");
        }
        id = int.Parse(Console.ReadLine());

        Console.WriteLine("Yeni ad daxil edin");
        name = Console.ReadLine();

        Console.WriteLine("Soyad daxil edin");
        surname = Console.ReadLine();

        Console.WriteLine("Maas Daxil edin");
        salary = double.Parse(Console.ReadLine());

        Console.WriteLine("Department Id daxil edin");
        foreach (var d in DbContext.Departments)
        {
            Console.WriteLine($"Departmentin ID`si: {d.Id} Departmentin adi: {d.Name}\n");
        }
        departmentId = int.Parse(Console.ReadLine());

        var exist = employeeRepository.Get(id);
        string nameTrim = name.Trim();
        string SurnameTrim = surname.Trim();
        var existDepartmentId = departmentRepository.Get(departmentId);

        if (exist != null)
        {
            if (nameTrim.Length > 2)
            {
                if (name.IsOnlyLetters())
                {
                    if (string.IsNullOrWhiteSpace(SurnameTrim))
                    {
                        if (SurnameTrim.IsOnlyLetters())
                        {
                            if (salary > 0)
                            {
                                if (existDepartmentId != null)
                                {
                                    check = true;
                                }
                                else
                                {
                                    Console.WriteLine("Bele bir department yoxdur");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Maas 0 dan boyuk olmalidir");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Soyad ancag herflerden ibraret olmalidir");
                        }
                    }
                    else
                    {
                        check = true;
                    }
                }
                else
                {
                    Console.WriteLine("Ad sadece herflerden ibaret olmalidir");
                }
            }
            else
            {
                Console.WriteLine("Adin uzunlugu 2 den cox olmalidir");
            }
        }
        else
        {
            Console.WriteLine("Bu ID li employe yoxdur");
        }

    } while (!check);
    employeeService.UpdateEmployee(name, surname, salary, id, departmentId);
}

void EmployeeGetById(EmployeeService employeeService)
{
    int id;
    bool check = false;
    do
    {
        Console.WriteLine("Secmek istediyiniz Employenin ID`Sni elave edin");
        foreach (var d in DbContext.Employees)
        {
            Console.WriteLine($"Employenin ID`si: {d.Id} Employenin adi: {d.Name}\n");
        }
        id = int.Parse(Console.ReadLine());
        var exist = DbContext.Employees.Find(c => c.Id == id);
        if (exist != null)
        {
            Console.WriteLine($"Axtaris Neticesi: {exist.Id} {exist.Name}");
            check = true;
        }
        else
        {
            Console.WriteLine($"Bu {id}`li Employee yoxdur ");
        }
    } while (!check);
    employeeService.EmployeeGetById(id);
}

void EmployeeGetAll(EmployeeService employeeService)
{
    Console.WriteLine("Butun Employellerin siyahisi: \n");
    foreach (var d in employeeService.EmployeeGetAll())
    {
        Console.WriteLine($"Employenin ID`si: {d.Id} Employenin Adi: {d.Name}");
    }
    employeeService.EmployeeGetAll();
}

void GetDepartmentEmployees(IDepartmentService departmentService)
{
    string name;
    bool check = false;
    do
    {
        foreach (var d in DbContext.Departments)
        {
            Console.WriteLine($"Departmentin ID`si: {d.Id} Departmentin adi: {d.Name}\n");
        }
        Console.WriteLine("Department adi daxil edin");
        name = Console.ReadLine();

        var departmentName = departmentRepository.GetByName(name);

        if (departmentName != null)
        {
            var employess = employeeRepository.GetAllDeparmentId(departmentName.Id);
            if (employess.Count != 0)
            {
                check = true;
                departmentService.GetDepartmentEmployees(name);
                foreach (var i in departmentService.GetDepartmentEmployees(name))
                {
                    Console.WriteLine(i);
                }
            }
            else
            {
                Console.WriteLine("Departmentde isci yoxdur");
                check = true;
            }
        }
        else
        {
            Console.WriteLine("Bele adda depaetment yoxdur");

        }
    } while (!check);

}

void AddEmployee(IDepartmentService departmentService)
{
    bool check = false;
    string name, surname;
    double salary;
    int departmentId;
    do
    {
        Console.WriteLine("Ad daxil edin");
        name = Console.ReadLine();

        Console.WriteLine("Soyad daxil edin");
        surname = Console.ReadLine();

        Console.WriteLine("Maas daxil edin:");
        salary = double.Parse(Console.ReadLine());

        Console.WriteLine("Secmek istediyiniz departmentin ID`Sni elave edin");
        foreach (var d in DbContext.Departments)
        {
            Console.WriteLine($"Departmentin ID`si: {d.Id} Departmentin adi: {d.Name}\n");
        }
        departmentId = int.Parse(Console.ReadLine());

        string NameTrim = name.Trim();
        string SurnameTrim = surname.Trim();

        var exist = DbContext.Departments.Find(d => d.Id == departmentId);

        if (exist != null)
        {
            if (NameTrim.Length > 2)
            {
                if (NameTrim.IsOnlyLetters())
                {
                    if (!string.IsNullOrWhiteSpace(SurnameTrim))
                    {
                        if (SurnameTrim.IsOnlyLetters())
                        {
                            if (salary > 0)
                            {
                                if (departmentService.GetDepartmentEmployees(exist.Name).Count < exist.EmployeeLimit)
                                {
                                    Employee employee = new Employee(name, surname, salary);
                                    employeeService.CreateEmployee(employee);
                                    if (employee.DepartmentId == 0)
                                    {
                                        check = true;
                                        departmentService.AddEmployee(employee, departmentId);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Employee basqa departmente aiddir");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Departmentde yer yoxdur");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Mass 0 dan boyuk olmalidir");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Soyad herflerden ibaret olmalidir");
                        }
                    }
                    else
                    {
                        check = true;
                    }
                }
                else
                {
                    Console.WriteLine("Ad herflerden ibaret olmalidir");
                }
            }
            else
            {
                Console.WriteLine("Ad uzunlugu 2 den cox olmaldir");
            }

        }
        else
        {
            Console.WriteLine("Department tapilmadi id yanlisdir");
        }

    } while (!check);
}

void CreateEmployee(EmployeeService employeeService)
{
    bool check = false;
    string name, surname;
    double salary;
    do
    {
        Console.WriteLine("Ad daxil edin");
        name = Console.ReadLine();
        Console.WriteLine("Soyad daxil edin");
        surname = Console.ReadLine();
        Console.WriteLine("Maas daxil edin:");
        salary = double.Parse(Console.ReadLine());

        string NameTrim = name.Trim();
        string SurnameTrim = surname.Trim();

        if (NameTrim.Length >= 2)
        {
            if (NameTrim.IsOnlyLetters())
            {
                if (!string.IsNullOrWhiteSpace(SurnameTrim))
                {
                    if (SurnameTrim.IsOnlyLetters())
                    {
                        if (salary > 0)
                        {
                            check = true;
                        }
                        else
                        {
                            Console.WriteLine("Maas 0 dan boyuk olmalidir");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Soyad ancag herflerden ibaret olmalidir");
                    }
                }
                else
                {
                    check = true;
                }
            }
            else
            {
                Console.WriteLine("Ad ancag herflerden ibaret olmalidir");
            }
        }
        else
        {
            Console.WriteLine("Adin uzunligi 2 den cox olmalidir");
        }
    } while (!check);
    Employee employee = new Employee(name, surname, salary);
    employeeService.CreateEmployee(employee);
}

void DepartmentGetById(IDepartmentService departmentService)
{
    int id;
    bool check = false;
    do
    {
        Console.WriteLine("Secmek istediyiniz departmentin ID`Sni elave edin");
        foreach (var d in DbContext.Departments)
        {
            Console.WriteLine($"Departmentin ID`si: {d.Id} Departmentin adi: {d.Name}\n");
        }
        id = int.Parse(Console.ReadLine());
        var exist = DbContext.Departments.Find(c => c.Id == id);
        if (exist != null)
        {
            Console.WriteLine($"Axtaris Neticesi: {exist.Id} {exist.Name}");
            check = true;
        }
        else
        {
            Console.WriteLine($"Bu {id}`li Department yoxdur ");
        }
    } while (!check);
    departmentService.DepartmentGetById(id);
}

void DepartmentGetAll(IDepartmentService departmentService)
{
    Console.WriteLine("Butun Departmentlerin siyahisi: \n");
    foreach (var d in departmentService.DepartmentGetAll())
    {
        Console.WriteLine($"Department ID`si: {d.Id} Department Adi: {d.Name}");
    }
    departmentService.DepartmentGetAll();
}

void DeleteDepartment(IDepartmentService departmentService)
{
    int departmentId;
    bool check = false;
    do
    {
        foreach (var i in DbContext.Departments)
        {
            Console.WriteLine($"Departmentin ID`si: {i.Id} Departmentin adi: {i.Name}\n");
        }

        Console.WriteLine("Silmek istediyiniz departmentin ID`sbi daxil edin:");
        departmentId = int.Parse(Console.ReadLine());
        var existDepartment = departmentRepository.Get(departmentId);

        if (existDepartment != null)
        {
            if (employeeRepository.GetAllDeparmentId(existDepartment.Id).Count == 0)
            {
                check = true;
            }
            else
            {
                Console.WriteLine("Bu departmentde isciler var evvelce iscileri silin sora departmenti");
            }
        }
        else
        {
            Console.WriteLine("Bu Id`li department yoxdur");
        }
    } while (!check);
    departmentService.DeleteDepartment(departmentId);
}

void UpdateDepartment(IDepartmentService departmentService)
{
    string? oldName;
    string? newName;
    int limit;
    bool check = false;
    do
    {
        foreach (var i in DbContext.Departments)
        {
            Console.WriteLine($"Departmentin ID`si: {i.Id} Departmentin adi: {i.Name}\n");
        }
        Console.WriteLine("Update etmek istediyiniz Departmentin adini daxil edin:");
        oldName = Console.ReadLine();
        Console.WriteLine("Yeni Adi daxil edin:");
        newName = Console.ReadLine();
        Console.WriteLine("Departmentin isci sayi limitini daxil edin:");
        limit = int.Parse(Console.ReadLine());

        var existOldName = departmentRepository.GetByName(oldName.Trim());
        var existNewName = departmentRepository.GetByName(newName.Trim());

        if (existOldName != null)
        {
            if (existNewName == null)
            {
                if (limit > 0)
                {
                    if (departmentService.GetDepartmentEmployees(oldName.Trim()).Count < limit)
                    {
                        if (oldName.Trim().ToLower() != newName.Trim().ToLower())
                        {
                            check = true;
                            departmentService.UpdateDepartment(oldName, newName, limit);
                        }
                        else
                        {
                            Console.WriteLine("Kohne adla yeni ad eyndir");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Yeni Limit departmentin icinde olan employelerin sayindan kicik ola bilmez");
                    }
                }
                else
                {
                    Console.WriteLine("Limit 0 dan boyuk olmalidir");
                }

            }
            else
            {
                Console.WriteLine("Yeni department name hal hazirda departmentlerde var");
            }
        }
        else
        {
            Console.WriteLine("Bu adda department yoxdur");
        }

    } while (!check);
}

void CreateDepartment(IDepartmentService departmentService)
{
    string name;
    int limit;
    int companyId;
    bool check = false;
    do
    {
        Console.WriteLine("Department Adi daxil edin");
        name = Console.ReadLine();
        Console.WriteLine("Limit daxil edin");
        limit = int.Parse(Console.ReadLine());
        foreach (var i in DbContext.Companys)
        {
            Console.WriteLine($"Sirketin ID`si: {i.Id} Sirketin adi: {i.Name}\n");
        }
        Console.WriteLine("Departmentin aid olacagi Companynin ID`sni yazin");
        companyId = int.Parse(Console.ReadLine());
        var exist = departmentRepository.GetByName(name.Trim());
        var company = companyRepository.Get(companyId);

        if (exist == null)
        {
            if (limit > 0)
            {
                if (company != null)
                {
                    check = true;
                }
                else
                {
                    Console.WriteLine("Bu ID`de Company yoxdur");
                }
            }
            else
            {
                Console.WriteLine("Limit 0 dan boyuk olmalidir");
            }
        }
        else
        {
            Console.WriteLine("Bu adda department var");
        }
    } while (!check);
    departmentService.CreateDepartment(name, limit, companyId);
}
void CreateCompany(CompanyService companyService)
{
    string? name;
    bool check = false;
    do
    {
        Console.Write("Ad daxil edin: ");
        name = Console.ReadLine();
        var exist = DbContext.Companys.Find(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        var names = companyService.CompanyGetAll();

        if (!string.IsNullOrEmpty(name))
        {
            if (exist == null)
            {
                check = true;
            }
            else
            {
                Console.WriteLine("Bu adda Company var");
            }
        }
        else
        {
            Console.WriteLine("Ad uygun deyil. Zehmet olmasa bir daha daxil edin \n");
        }
    } while (!check);
    companyService.CreateCompany(name);
}

void UpdateCompany(CompanyService companyService)
{
    string? newName;
    string? oldName;
    bool check = false;
    do
    {
        foreach (var company in DbContext.Companys)
        {
            Console.WriteLine($"Sirketin adi {company.Name}\n");
        }
        Console.WriteLine("Deyismek istediyiniz Company`nin adini daxil edin");
        oldName = Console.ReadLine();
        Console.WriteLine("Yeni Adi daxil edin");
        newName = Console.ReadLine();
        var exist = DbContext.Companys.Find(c => c.Name == oldName.Trim());
        var existNewName = DbContext.Companys.Find(c => c.Name == newName.Trim());
        if (oldName.Trim().Length > 0)
        {
            if (exist != null)
            {
                if (existNewName == null)
                {
                    if (oldName.Trim().ToLower() != newName.Trim().ToLower())
                    {
                        check = true;
                    }
                    else
                    {
                        Console.WriteLine("Adlar eynidir");
                    }
                }
                else
                {
                    Console.WriteLine("Bu ad hal hazirda var");
                }
            }
            else
            {
                Console.WriteLine("Bu adda Company yoxdur");
            }
        }
        else
        {
            Console.WriteLine("Sozun uzunlugu azdir");
        }
    } while (!check);
    companyService.UpdateCompany(oldName, newName);
}
void DeleteCompany(CompanyService companyService)
{
    int id;
    bool check = false;
    do
    {
        foreach (var company in DbContext.Companys)
        {
            Console.WriteLine($"Sirketin ID`si: {company.Id} Sirketin adi: {company.Name}\n");
        }
        Console.WriteLine("Silmek istediyiniz sirketin ID`Sni elave edin");
        id = int.Parse(Console.ReadLine());
        var exist = DbContext.Companys.Find(c => c.Id == id);
        if (exist != null)
        {
            if (departmentRepository.GetAllCompanyId(id).Count == 0)
            {
                check = true;
            }
            else
            {
                Console.WriteLine("Departmentde isciler var silmek mumkun deyil");
            }
        }
        else
        {
            Console.WriteLine("Bu ID`de Company yoxdur");
        }
    } while (!check);
    companyService.DeleteCompany(id);
}

void CompanyGetById(CompanyService companyService)
{
    int id;
    bool check = false;
    do
    {
        Console.WriteLine("Secmek istediyiniz sirketin ID`Sni elave edin");
        foreach (var company in DbContext.Companys)
        {
            Console.WriteLine($"Sirketin ID`si: {company.Id} Sirketin adi: {company.Name}\n");
        }
        id = int.Parse(Console.ReadLine());
        var exist = DbContext.Companys.Find(c => c.Id == id);
        if (exist != null)
        {
            Console.WriteLine($"Axtaris Neticesi: {exist.Id} {exist.Name}");
            check = true;
        }
        else
        {
            Console.WriteLine($"Bu {id}`li company yoxdur ");
        }
    } while (!check);
    companyService.CompanyGetById(id);
}
void CompanyGetAll(CompanyService companyService)
{
    Console.WriteLine("Butun Sirketlerin siyahisi: \n");
    foreach (var company in companyService.CompanyGetAll())
    {
        Console.WriteLine($"Sirket ID`si: {company.Id} Sirket Adi: {company.Name}");
    }
    companyService.CompanyGetAll();
}
void GetAllDepartment(CompanyService companyService)
{
    string name;
    bool check = false;
    do
    {
        foreach (var company in companyService.CompanyGetAll())
        {
            Console.WriteLine($"Sirket ID`si: {company.Id} Sirket Adi: {company.Name}");
        }
        Console.WriteLine("Sirketin adini daxil edin:");
        name = Console.ReadLine();

        var exist = companyRepository.GetByName(name.Trim());

        if (exist != null)
        {
            var existCompanyId = departmentRepository.GetAllCompanyId(exist.Id);
            foreach (var i in companyService.GetAllDepartment(name))
            {
                Console.WriteLine(i);
            }
            check = true;
            if (existCompanyId.Count == 0)
            {
                Console.WriteLine("Department yoxdur bu Sirketde");
            }
        }
        else
        {
            Console.WriteLine("Axtardiginiz adda sirket yoxdur");
        }
    } while (!check);
}