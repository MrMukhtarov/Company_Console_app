namespace ConsoleProject.Business.Helpers;

public static class Helper
{
    public static Dictionary<string, string> Error = new Dictionary<string, string>()
    {
        {"SizeException","Length doesn't match"},
        {"AlreadyExistException","This object already exist" },
        {"ObjectNotFoundException","Object is not found" },
        {"SameNameException","Object with this name is already exits" },
        {"LimitDoesNotMatchException","Limit does not match" },
        {"ObjectDoesNotEmptyExcepion","Object does not empty." },
        {"PatternDoesNotMatchException", "Pattern does not match" },
        {"CannotBeLessThanZeroException", "Cannot be Less Than Zero" },
        {"EmployeeHasDepartmentIdException", "Employee already Has DepartmentId" },
        {"CapacityLimitException","exceeded the limit capacity" }
    };
}
