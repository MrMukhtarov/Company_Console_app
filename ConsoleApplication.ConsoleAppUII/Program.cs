using ConsoleProject.Business.Services;
using ConsoleProjetc.DataAccess.Context;
using ConsoleProjetc.DataAccess.Implementations;
using System.Xml.Linq;

CompanyService companyService = new CompanyService();
IDepartmentService departmentService = new IDepartmentService();
EmployeeService employeeService = new EmployeeService();
DepartmentRepository departmentRepository = new DepartmentRepository();
CompanyRepository companyRepository = new CompanyRepository();

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
            break;
        case 9:
            break;
        case 10:
            Console.Clear();
            break;
        case 11:
            Console.Clear();
            break;
        case 12:
            Console.Clear();
            break;
        case 13:
            Console.Clear();
            break;
        case 14:
            Console.Clear();
            break;
        case 15:
            Console.Clear();
            break;
        case 16:
            Console.Clear();
            break;
        case 17:
            Console.Clear();
            break;
        case 18:
            Console.Clear();
            break;
        case 19:
            return;
    }
} while (true);

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
        
        if(exist == null)
        {
            if(limit > 0)
            {
                if(company != null)
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
    }while (!check);
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
        Console.WriteLine("Silmek istediyiniz sirketin ID`Sni elave edin");
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
            foreach(var i in companyService.GetAllDepartment(name))
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



