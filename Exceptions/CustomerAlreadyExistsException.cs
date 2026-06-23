namespace Lowes.CustomerManagement.Exceptions;

public class CustomerAlreadyExistsException : Exception
{
    public CustomerAlreadyExistsException(
        string message)
        : base(message)
    {
    }
}