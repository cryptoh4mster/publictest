using Netto.Public.Domain.Exceptions.BusinessExceptions;

namespace Netto.Public.Domain.Exceptions
{
    public class RequestLimitExceededException : BusinessNettoException
    {
        public RequestLimitExceededException() : base("Request limit exceeded")
        {

        }
    }
}
