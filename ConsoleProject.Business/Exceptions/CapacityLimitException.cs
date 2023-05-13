namespace ConsoleProject.Business.Exceptions;

internal class CapacityLimitException : Exception
{
    public CapacityLimitException(string message) : base(message)
    {

    }
}
