using Library.BLL.Exceptions;
using System.Net;

namespace Library.Api.CustomExceptionMiddleware;

public class ExceptionService : IExceptionsService
{
  
        private readonly Dictionary<Type, HttpStatusCode> _statusCodes;

        public ExceptionService()
        {
            _statusCodes = new Dictionary<Type, HttpStatusCode>()
        {
            { typeof(NotFoundException), HttpStatusCode.NotFound },
            { typeof(InvalidDataException), HttpStatusCode.BadRequest },
            { typeof(UserAlreadyExistsException), HttpStatusCode.Conflict },
            { typeof(UserDoesNotExistException), HttpStatusCode.NotFound },
            { typeof(RegistrationFailedException), HttpStatusCode.BadRequest },
        };
        }

        public HttpStatusCode GetStatusCodeAndMessageOnException(Exception exception)
        {
            if (!_statusCodes.ContainsKey(exception.GetType()))
            {
                return HttpStatusCode.InternalServerError;
            }

            return _statusCodes[exception.GetType()];
        }
    
}
