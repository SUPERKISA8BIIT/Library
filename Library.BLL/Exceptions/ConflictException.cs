
namespace Library.BLL.Exceptions
{
    public class ConflictException : BusinessLogicEcxeption
    {
        public ConflictException() { }
        public ConflictException(string message) : base(message) { }
        public ConflictException(string message, Exception inner)
            : base(message, inner) { }
    }
}
