namespace Library.BLL.Exceptions;

public class UserAlreadyExistsException : BusinessLogicEcxeption
{
    public UserAlreadyExistsException() { }
    public UserAlreadyExistsException(string message) : base(message) { }
    public UserAlreadyExistsException(string message, Exception inner)
        : base(message, inner) { }
}
