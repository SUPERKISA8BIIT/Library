namespace Library.BLL.Exceptions;

public class NotFoundException : BusinessLogicEcxeption
{
    public NotFoundException() { }
    public NotFoundException(string message) : base(message) { }
    public NotFoundException(string message, Exception inner)
        : base(message, inner) { }
}
