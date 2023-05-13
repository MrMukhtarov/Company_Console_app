namespace ConsoleProject.Business.Exceptions;

internal class EmployeeHasDepartmentIdException : Exception
{
    public EmployeeHasDepartmentIdException(string message) : base(message)
    {

    }
}
