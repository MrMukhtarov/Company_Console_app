namespace ConsoleProject.Business.Exceptions;

internal class PatternDoesNotMatchException : Exception
{
    public PatternDoesNotMatchException(string message) : base(message)
    {

    }
}
