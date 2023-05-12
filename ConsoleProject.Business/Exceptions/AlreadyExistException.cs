namespace ConsoleProject.Business.Exceptions;

internal class AlreadyExistException : Exception
{
    public AlreadyExistException(string message) : base(message)
    {

    }
}
