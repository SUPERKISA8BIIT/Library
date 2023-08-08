namespace Library.BLL.Exceptions;

public class IncorrectEmailOrPasswordException : BusinessLogicEcxeption
{
    public IncorrectEmailOrPasswordException() { }
    public IncorrectEmailOrPasswordException(string message) : base(message) { }
    public IncorrectEmailOrPasswordException(string message, Exception inner)
        : base(message, inner) { }
}
