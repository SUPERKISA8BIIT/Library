namespace Library.BLL.Exceptions;

public class RegistrationFailedException : BusinessLogicEcxeption
{
    public RegistrationFailedException() { }
    public RegistrationFailedException(string message) : base(message) { }
    public RegistrationFailedException(string message, Exception inner)
        : base(message, inner) { }
}
