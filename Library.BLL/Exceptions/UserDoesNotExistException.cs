
namespace Library.BLL.Exceptions;

public class UserDoesNotExistException : BusinessLogicEcxeption
{
    public UserDoesNotExistException() { }
    public UserDoesNotExistException(string message) : base(message) { }
    public UserDoesNotExistException(string message, Exception inner)
        : base(message, inner) { }
}
