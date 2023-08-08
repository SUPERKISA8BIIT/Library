using System.Net;

namespace Library.Api.CustomExceptionMiddleware
{
    public interface IExceptionsService
    {
        HttpStatusCode GetStatusCodeAndMessageOnException(Exception exception);
    }
}