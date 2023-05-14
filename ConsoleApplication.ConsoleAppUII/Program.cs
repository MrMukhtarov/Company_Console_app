using ConsoleProject.Business.Services;
using ConsoleProjetc.DataAccess.Context;
using System.Xml.Linq;

CompanyService companyService = new CompanyService();
IDepartmentService departmentService = new IDepartmentService();
EmployeeService employeeService = new EmployeeService();
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
            Create(companyService);
            break;
        case 2:
            Console.Clear();
            Update(companyService);
            break;
        case 3:
            Console.Clear();
            break;
        case 4:
            Console.Clear();
            break;
        case 5:
            Console.Clear();
            break;
        case 6:
            Console.Clear();
            break;
        case 7:
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

void Create(CompanyService companyService)
{
    string? name;
    bool check = false;
    do
    {
        Console.Write("Ad daxil edin: ");
        name = Console.ReadLine();
        var exist = DbContext.Companys.Find(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        var names = companyService.GetAll();

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
    companyService.Create(name);
}

void Update(CompanyService companyService)
{
    string? newName;
    string? oldName;
    bool check = false;
    do
    {
        Console.WriteLine("Deyismek istediyiniz Company`nin adini daxil edin");
        oldName = Console.ReadLine();
        Console.WriteLine("Yeni Adi daxil edin");
        newName = Console.ReadLine();
        var exist = DbContext.Companys.Find(c => c.Name == oldName.Trim());
        if (oldName.Trim().Length > 0)
        {
            if (exist != null)
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
                Console.WriteLine("Bu adda Company yoxdur");
            }
        }
        else
        {
            Console.WriteLine("Sozun uzunlugu azdir");
        }
    } while (!check);
    companyService.Update(oldName, newName);
}