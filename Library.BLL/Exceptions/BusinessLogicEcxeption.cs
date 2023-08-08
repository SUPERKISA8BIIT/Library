namespace Library.BLL.Exceptions;

public abstract class BusinessLogicEcxeption : Exception
{
    public BusinessLogicEcxeption() { }
    public BusinessLogicEcxeption(string message)
        : base(message) { }
    public BusinessLogicEcxeption(string message, Exception inner)
        : base(message, inner) { }
}
